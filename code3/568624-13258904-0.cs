    public class Invoice : INotifyPropertyChanged
        {
    
            private bool payedInFull = false;
            public bool PayedInFull
            {
                get { return payedInFull; }
                set
                {
                    payedInFull = value;
                    NotifyPropertyChanged("PayedInFull");
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion
        }
