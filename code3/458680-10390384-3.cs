    public class MainWindowViewModel
    {
    	public ObservableCollection<FooViewModel> FooViewModels { get; set; }
    
    	public ICommand HelpExecuted { get; set; }
    
    	public MainWindowViewModel()
    	{
    		FooViewModels = new ObservableCollection<FooViewModel>();
    		HelpExecuted = new DelegateCommand(ShowHelp);
    	}
    
    	private void ShowHelp(object obj)
    	{
    		// Yay!
    	}
    }
