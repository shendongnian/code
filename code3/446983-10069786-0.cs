    public class Person: INotifyPropertyChanged
    {
        private string name;
        ...       
        public event PropertyChangedEventHandler PropertyChanged;
            
        public string FullName
        {
            get {return this.name;}
    
            set
            {
                if (value != this.name)
                {
                    this.name= value;
                    NotifyPropertyChanged("FullName");
                }
            }
        }
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
