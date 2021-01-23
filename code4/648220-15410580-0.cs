    public class MessageBoxDisplayEventArgs : EventArgs
    {
    	public string Title { get; set; }
    	
    	// Other properties here...
    }
    ...
    public class ViewModelBase
    {
    	public event EventHandler<MessageBoxDisplayEventArgs> MessageBoxDisplayRequested;
    	
    	protected void OnMessageBoxDisplayRequest(string title)
    	{
    		if (this.MessageBoxDisplayRequested != null)
    		{
    			this.MessageBoxDisplayRequested(
    				this, 
    				new MessageBoxDisplayEventArgs
    				{
    					Title = title
    				});
    		}
    	}
    }
    ...
    public class YourViewModel : ViewModelBase
    {
    	private void SomeMethod()
    	{
    		this.OnMessageBoxDisplayRequest("hello world");
    	}
    }
    ...
    public class YourView
    {
    	public YourView()
    	{
    		var vm = new YourViewModel();
    		this.Datacontext = vm;
    		
    		vm.MessageBoxDisplayRequested += (sender, e) =>
    		{
    			// UI logic here
    			//MessageBox.Show(e.Title);
    		};
    	}
    }
