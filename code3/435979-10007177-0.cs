        public sealed class DataGridClass:INotifyPropertyChanged
    {
          private static readonly DataGridClass instance = new DataGridClass();
          private DataGridClass() { }
          public static DataGridClass Instance
           {
              get 
              {
                 return instance; 
              }
           }
          
        private int _DataGridFontSize {get;set;}
        
        public int DataGridFontSize
        {
            get { return _DataGridFontSize; }
            set { _DataGridFontSize = value;
                RaisePropertyChanged("DataGridFontSize");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
