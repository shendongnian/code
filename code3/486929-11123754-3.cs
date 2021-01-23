    public class ViewModel
    {
        public ViewModel() {
            //get the Database reference from somewhere?
            this.DeleteMapCommand = new DeleteMapsCommand(this.Database); 
        }
        public ICommand DeleteMapCommand { get; private set; }
    }
