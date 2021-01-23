    public class ResourceListViewModel
    {
        public RelayCommand OpenCommand {get;set;}
    
        public ResourceListViewModel()
        {
            OpenCommand = new RelayCommand(ExecuteOpenCommand, CanExecuteOpenCommand);
        }
    
        //etc etc
    }
