        RelayCommand _toogleButtonCommand;
        public ICommand ToogleButtonCommand
        {
            get
            {
                if (_toogleButtonCommand == null)
                {
                    _toogleButtonCommand = new RelayCommand(this.DoSomethingExecute,
                        this.DoSomethingCanExecute);
                }
                return _toogleButtonCommand;
            }
        }
        public void DoSomethingExecute(object param)
        {
           int result = Convert.ToInt32(param);
            if (result == 16)
            {
                //To this and so on for example
            }
        }
