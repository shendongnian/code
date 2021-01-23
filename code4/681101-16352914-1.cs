    public ICommand DeleteCommand 
        {
            get 
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(x => Remove(null));
                }
                return deleteCommand;
            }           
        }  
