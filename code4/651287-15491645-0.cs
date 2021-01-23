    int _myValue;
    public int MyValue{get{return _myValue;}set{_myValue = value; NotifyPropertyChanged("MyValue");}}
    
      private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
         {
              MyValue = Convert.ToInt32(Math.Floor(e.NewValue));
         }
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
