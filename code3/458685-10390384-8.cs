    public class FooViewModel
    {
        public ICommand HelpExecuted { get; set; }
        public FooViewModel()
    	{
     		HelpExecuted = new DelegateCommand(ShowHelp);
    	}
    
    	private void ShowHelp(object obj)
    	{
    		// Yay!
    	}
    }
