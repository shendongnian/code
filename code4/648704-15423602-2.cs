    public class Node: INotifyPropertyChanged
        {
            private double _x;
            public double X
            {
                get { return _x; }
                set
                {
                    //"Grid Snapping"
                    //this actually "rounds" the value so that it will always be a multiple of 50.
                    _x = (Math.Round(value / 50.0)) * 50;
                    OnPropertyChanged("X");
                }
            }
    
            private double _y;
            public double Y
            {
                get { return _y; }
                set
                {
                    //"Grid Snapping"
                    //this actually "rounds" the value so that it will always be a multiple of 50.
                    _y = (Math.Round(value / 50.0)) * 50;
                    OnPropertyChanged("Y");
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    public class Connector
    {
        public Node Start { get; set; }
        public Node End { get; set; }
    }
