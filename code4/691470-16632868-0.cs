    public class CurveViewModel : ViewModelBase
    {
        public ObservableCollection<Coordinate> UserInputCoordinates { get; private set; }
    
        public CurveViewModel()
        {
            UserInputCoordinates = new ObservableCollection<Coordinate>();
        }
    
        public class Coordinate : ViewModelBase
        {
            private double _xStart;
            
            public double XStart
            {
                get { return _xStart; }
                set
                {
                    _xStart = value;
                    OnPropertyChanged("XStart");
                }
            }
    
            // Analogous properties for YStart, XEnd, YEnd, XControl, YControl
        }
    }
