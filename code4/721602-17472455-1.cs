    public class MyCustomAppStart : MvxNavigatingObject, IMvxAppStart
    {
    	public void Start(object hint = null)
    	{
    		if(hint is string)
    		    ShowViewModel<ScanViewModel>(new {url = (string)hint});
    		else
    		    ShowViewModel<ScanViewModel>();
    	}
    }
