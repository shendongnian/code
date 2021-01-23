    public class ObservalbeList<T>: INotifyPropertyChanged
    {
        private BindingList<T> ts = new BindingList<T>();
        
        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged( String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public BindingList<T> Ts
        {
            get { return ts; }
            set
            {
                if (value != ts)
                {
                    Ts = value;
                    if (Ts != null)
                    {
                        ts.ListChanged += delegate(object sender, ListChangedEventArgs args)
                        {
                            OnPeopleListChanged(this);
                        };
                    }
                    NotifyPropertyChanged("Ts");
                }
            }
        }
        private static void OnPeopleListChanged(ObservalbeList<T> vm)
        {
            vm.NotifyPropertyChanged("Ts");
        }
        public ObservalbeList()
        {
            ts.ListChanged += delegate(object sender, ListChangedEventArgs args)
            {
                OnPeopleListChanged(this);
            };
        }
    }
