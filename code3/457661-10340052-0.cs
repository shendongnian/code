    //Your current abstract base class
    public abstract class BaseClass
    {
    	private Page _page;
    	protected abstract IControlProvider ControlProvider { get; }
    	
    	public BaseClass(Page page)
    	{
    		_page = page;
    		page.Init += (s, ev) => page.LoadControl(ControlProvider.Path);
    	}
    	
       	public void Run()
    	{
    	}
    }
    
    //UI control interface provider
    public interface IControlProvider
    {
    	UserControl Control { get; }
    	
    	string Path { get; }
    	
    	object GetRelevantValue();
    }
    
    //Example implementation
    public class MyControlProvider : IControlProvider
    {
    	private MyUserControl _ctrl;
    	
    	UserControl Control { get { return _ctrl; } }
    	
    	public string Path { get { return "~/dir/ctrl.ascx"; } }
    	
    	public object GetRelevantValue()
    	{
    	 	return _ctrl.GetData();
    	}
    	
    	public MyControlProvider()
    	{
    		_ctrl = new MyUserControl();
    	}
    }
