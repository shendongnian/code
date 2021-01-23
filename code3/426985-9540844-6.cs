        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
