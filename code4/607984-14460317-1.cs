        public ICommand MyCommand
        {
            get
            {
                return new RelayCommand(this.MyCommandExecute);
            }
        }
        
        private void MyCommandExecute()
        {
            // DO Something...
        }
