    public sealed class ValueWrapper : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      public ValueWrapper(byte initialValue) {
         _value = initialValue;
      }      
      private byte _value;
      public byte Value {
         get { return _value; }
         set { 
            _value = value;
            OnPropertyChanged("Value");
         }
      }
    
      private void OnPropertyChanged(String name)
      {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
      }
    }
