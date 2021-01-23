    public class MainWindowViewModel
    {
    	public ObservableCollection<FooViewModel> FooViewModels { get; set; }
    
    	public MainWindowViewModel()
    	{
    		FooViewModels = new ObservableCollection<FooViewModel>();
    	}
    }
