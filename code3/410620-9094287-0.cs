    public class ViewModel
    {
    	ObservableCollection<DirectoryItem> Directories = new ObservableColelction<DirectoryItem>();
    	
    	// call LoadFromLocalStorage() and add items to this Directories  list	
    
    }
    
    public class DirectoryItem:INotifyPropertyChanged
    {
    	string _name;
    
    	ObservableCollection<string> Files;
    	
    	public DirectoryItem()
    	{
    		_name = null;
    		Files = new ObservableCollection<string>();
    	}
    
    	//write public set and get for Name field.
    	
    	//notify whenever property changes
    }
