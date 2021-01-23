     public partial class W3 : UserControl
        {
            WeatherViewModel model = new WeatherViewModel();
    
            public W3()
            {
                InitializeComponent();
                this.DataContext = model;
            }
    
            public void UpdateUI(List<WeatherDetails> data, bool isNextDays)
            {
                model.UpdateUI(data, isNextDays);
            }
        }
    
        class WeatherViewModel : INotifyPropertyChanged
        {     
    
            public void UpdateUI(List<WeatherDetails> data, bool isNextDays)
            {
                List<WeatherDetails> weatherInfo = data;
                if (weatherInfo.Count != 0)
                {
                    CurrentWeather = weatherInfo.First();
                    if (isNextDays)
                        Forecast = weatherInfo.Skip(1).ToList();
                }
            }
    
            private List<WeatherDetails> _forecast = new List<WeatherDetails>();
    
            public List<WeatherDetails> Forecast
            {
                get { return _forecast; }
                set
                {
                    _forecast = value;
                    OnPropertyChanged("Forecast");
                }
            }
    
            private WeatherDetails _currentWeather = new WeatherDetails();
    
            public WeatherDetails CurrentWeather
            {
                get { return _currentWeather; }
                set
                {
                    _currentWeather = value;
                    OnPropertyChanged("CurrentWeather");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
