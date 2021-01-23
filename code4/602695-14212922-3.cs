        private ICommand showAddCommand;
        public ICommand ShowAddCommand
        {
            get
            {
                if (this.showAddCommand == null)
                {
                    this.showAddCommand = new RelayCommand(this.SaveFormExecute, this.SaveFormCanExecute);
                }
                return this.showAddCommand;
            }
        }
        private bool SaveFormCanExecute()
        {
            return !string.IsNullOrEmpty(DCNotes);
            
        }
        private void SaveFormExecute()
        {
            Insertcustomer(); //This a method that inserts data to database
        }
