using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //api details 
        const string APPID = "";
        string cityName = "London";



        public MainWindow()
        {
            InitializeComponent();
            getWeather();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
           
        }

        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=London&appid=291c93497e96ae5f8e2b01e60a34a1c1&unit=metric");

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);

                weatherInfo.root outPut = result;

                tbCountry.Text = string.Format("{0}", outPut.sys.country);
                tbTemperatur.Text = string.Format("{0}", outPut.main.temp);
                tbWind.Text = string.Format("{0}", outPut.wind.speed);
                tbHumidity.Text = string.Format("{0}", outPut.main.humidity);
                tbPressure.Text = string.Format("{0}", outPut.main.pressure);


            }
            
        }

        
    }
}
