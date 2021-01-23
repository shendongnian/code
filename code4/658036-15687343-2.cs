    public class FooViewModel : INotifyPropertyChanged
    {
        private int currentPareto;
        public int CurrentPareto 
        {
            get
            {
               return currentPareto;
            }
            set
            { 
                if (currentPareto == value)
                    return;
                
                currentPareto = value;
                OnPropertyChanged("CurrentPareto");
                OnPropertyChanged("pNew");
            }
        }
        private int newPareto;
        public int NewPareto 
        {
            get
            {
               return newPareto;
            }
            set
            { 
                if (newPareto == value)
                    return;
                
                newPareto = value;
                OnPropertyChanged("NewPareto");
                OnPropertyChanged("pNew");
            }
        }
        public bool pNew
        {
            get
            {
                return CurrentPareto < NewPareto;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
