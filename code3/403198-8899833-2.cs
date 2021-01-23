    class MainWindowContext
    {
        RelayCommand _openCommand;
        public ICommand OpenCommand
        {
            get
            {
                if (_openCommand == null)
                {
                    _openCommand = new RelayCommand(
                        param => this.Open(),
                        param => this.Open_CanExecute());
                }
                return _openCommand;
            }
    
            set { _openCommand = (RelayCommand) value; }
            
        }
    
        RelayCommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new RelayCommand(
                        param => this.Copy(),
                        param => this.Copy_CanExecute());
                }
                return _copyCommand;
            }
    
            set { _copyCommand = (RelayCommand)value; }
    
        }
    
        private bool Copy_CanExecute()
        {
            return true;
        }
    
        private object Copy()
        {
            Console.Out.WriteLine("Copy command executed");
            return null;
        }
    
        private bool Open_CanExecute()
        {
            return true;
        }
    
        private object Open()
        {
            Console.Out.WriteLine("Open command executed");
            return null;
        }
    }
