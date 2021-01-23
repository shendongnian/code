    public class ObservableCollection<T>: INotifyPropertyChanged
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
                            OnListChanged(this);
                        };
                    }
                    NotifyPropertyChanged("Ts");
                }
            }
        }
        private static void OnListChanged(ObservableCollection<T> vm)
        {
            // this will fire on add, remove, and change
            // if want to prevent an insert this in not the right spot for that 
            // the OPs use of word prevent is not clear 
            // -1 don't be a hater
            vm.NotifyPropertyChanged("Ts");
        }
        public ObservableCollection()
        {
            ts.ListChanged += delegate(object sender, ListChangedEventArgs args)
            {
                OnListChanged(this);
            };
        }
    }
