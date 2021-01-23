    public abstract class BaseClass<T> where T: UserControl, IMyControl
    {
    	private Page _page;
    	protected T Control { get; private set;}
    	
    	public BaseClass(Page page, string controlPath)
    	{
    		_page = page;
    		Control = (T)page.LoadControl(controlPath);
            _page.Controls.Add(Control);
    	}
    	
       	public void Run()
    	{
    		var data = Control.GetData();
    	}
    }
    
    public interface IMyControl
    {
     	object GetData();
    }
