    private RelayCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if(this._CloseCommand==null)
                    this._CloseCommand=new RelayCommand(CloseClick);
                return this._CloseCommand;
            }
        }
        private void CloseClick(object obj)
        {
            OnRequestClose();
        }
