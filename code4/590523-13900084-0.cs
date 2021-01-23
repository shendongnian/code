       public ICommand test
        {
            get { return testCommand; }
            set { testCOmmand = value; NotifyPropertyChanged("test"); }
        }
