       RelayCommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                         param => this.Delete(param), 
                         param => this.CanDelete(param));
                }
                return _deleteCommand;
            }
        }
 
