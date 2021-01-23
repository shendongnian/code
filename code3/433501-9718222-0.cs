    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string type;
        public string Type
        {
          get { return type; }
          set
          {
             if (value != type)
             {
                type = value;
                NotifyPropertyChanged("Type");
             }
          }
        }
        // ... more properties
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
