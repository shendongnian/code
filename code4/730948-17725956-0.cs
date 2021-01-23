    public class MyClass: INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
      {
          var handler = PropertyChanged;
          if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
      }
      
      private double _slider1;
    
      public double Slider1
      {
          get { return _slider1; }
          set
          {
              if (_slider1 != value)
              {
                  _slider1 = value;
                  OnPropertyChanged("Slider1");
                  if (_slider1 > Slider2) Slider2 = _slider1;
              }
          }
      }
    
      private double _slider2;
    
      public double Slider2
      {
          get { return _slider2; }
          set
          {
              if (_slider2 != value)
              {
                  _slider2 = value;
                  OnPropertyChanged("Slider2");
                  if (_slider2 < Slider1) Slider1 = _slider2;
              }
          }
      }
    }
