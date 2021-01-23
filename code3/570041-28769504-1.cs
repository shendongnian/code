    public class Lecturer : INotifyPropertyChanged
    {
        //public Lecturer(){} <- not necessary
        
        private int _id;
        public int Id 
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        // continue doing the above property change to all the properties you want your UI to notice their changes.
    
        ...
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
