     public class MovableObject: INotifyPropertyChanged
        {
            private double _x;
            public double X
            {
                get { return _x; }
                set
                {
                    _x = value;
                    OnPropertyChanged("X");
                }
            }
    
            private double _y;
            public double Y
            {
                get { return _y; }
                set
                {
                    _y = value;
                    OnPropertyChanged("Y");
                }
            }
    
            private System.Threading.Timer MoveTimer;
    
            private double DestinationX;
            private double DestinationY;
    
            public void MoveToPosition(double x, double y)
            {
                DestinationX = x;
                DestinationY = y;
    
                if (MoveTimer != null)
                    MoveTimer.Dispose();
    
                MoveTimer = new Timer(o => MoveStep(), null, 0, 10);
            }
    
            private void MoveStep()
            {
                if (Math.Abs(X - DestinationX) > 5)
                {
                    if (X < DestinationX)
                        X = X+5;
                    else if (X > DestinationX)
                        X = X-5;    
                }
    
                if (Math.Abs(Y - DestinationY) > 5)
                {
                    if (Y < DestinationY)
                        Y = Y + 5;
                    else if (Y > DestinationY)
                        Y = Y - 5;    
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        PropertyChangedEventHandler handler = PropertyChanged;
                        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));        
                    }));
                
            }
        }
