        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;          // +
            if (handler != null)                                            // ~
            {
                handler(this, new PropertyChangedEventArgs(propertyName));  // ~
            }
        }
