        private UserControl currentView;
        public UserControl CurrentView
        {
            get
            {
                return this.currentView;
            }
            set
            {
                if (this.currentView == value)
                {
                    return;
                }
                this.currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }
