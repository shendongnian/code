    public partial class MyView : UserControl, INavigationAware
    {
    // some hidden code
    
    	public void OnNavigatedTo(NavigationContext navigationContext)
    	{
    		int hash = int.Parse(navigationContext.Parameters["hash"]);
    		Customer cust = (Customer)Parameters.request(hash);
    	}
    }
