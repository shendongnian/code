     public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String str)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(str);
                PropertyChanged(this, e);
            }
        }
