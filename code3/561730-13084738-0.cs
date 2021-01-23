    public class TempModel
    {
        private double _kelvin;
        public double Kelvin
        {
            get
            {
                return _kelvin;
            }
            set
            {
                _kelvin = value;
                OnPropertyChanged("Kelvin");
                OnPropertyChanged("Celsius");
                OnPropertyChanged("Fahrenheit");
            }
        }
        public double Celsius
        {
            get
            {
                return _kelvin - 273.15;
            }
            set
            {
                _kelvin = value + 273.15;
                OnPropertyChanged("Celsius");
                OnPropertyChanged("Kelvin");
                OnPropertyChanged("Fahrenheit");
            }
        }
        public double Fahrenheit
        {
            get
            {
                return 9.0 / 5.0 * (_kelvin - 273.15) + 32;
            }
            set
            { 
                _kelvin = 5.0 / 9.0 * (value - 32) + 273.15;
                OnPropertyChanged("Fahrenheit");
                OnPropertyChanged("Celsius");
                OnPropertyChanged("Kelvin");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class TempViewModel
    {
        TempModel _tempModel;
        public TempViewModel()
        {
            _tempModel = new TempModel 
            {
                Kelvin = 300.15 // Initial value
            };
        }
        public TempModel TempModel
        {
            get
            {
                return _tempModel;
            }
            set
            {
                _tempModel = value;
            }
        }
    }
    <Grid VerticalAlignment="Stretch">
    
    <extToolkit:DoubleUpDown Increment="0.1" FormatString="F2" Value="{Binding TempModel.Kelvin}" HorizontalAlignment="Left" Width="100" VerticalAlignment="Top" Margin="113,14,0,0" />
    
    <extToolkit:DoubleUpDown  Increment="0.1" FormatString="F2" Value="{Binding TempModel.Celsius}" HorizontalAlignment="Left" Width="100" VerticalAlignment="Top" Margin="113,48,0,0" />
    
    <extToolkit:DoubleUpDown  Increment="0.1" FormatString="F2" Value="{Binding TempModel.Fahrenheit}" HorizontalAlignment="Left" Width="100" VerticalAlignment="Top" Margin="113,82,0,0" />
    </Grid> 
