    public class Node:INotifyPropertyChanged
    {
    
           #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
         string _name ;
          public string Name
          {
              get { return _name; }
              set
              {
                  _name = value;
                   OnPropertyChanged("Name");
              }
          }
    .....
