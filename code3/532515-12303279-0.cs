    public class PanelPresentatinLogic
    {
    	public Panel Panel{get;set;}	 
    
    	public void DoSomeDuplicatingStuff()
    	{
    		//Do stuff! with Panel
    	}	 
    }
    
    public class SortOfStackPanel : StackPanel
    {
    	private readonly PanelPresentatinLogic _panelPresentatinLogic;
    
    	public SortOfStackPanel(PanelPresentatinLogic presentationLogic)
    	{
    		_panelPresentatinLogic = presentationLogic;
    		_panelPresentatinLogic.Panel = this;
    	}
    
    	public void DoSomeDuplicatingStuff()
    	{
    		_panelPresentatinLogic.DoSomeDuplicatingStuff();
    	}
    }
    
    
    public class SortOfWrapPanel : WrapPanel
    {
    	private readonly PanelPresentatinLogic _panelPresentatinLogic;
    	
    	public SortOfWrapPanel(PanelPresentatinLogic presentationLogic)
    	{
    		_panelPresentatinLogic = presentationLogic;
    		_panelPresentatinLogic.Panel = this;
    	}
    
    	public void DoSomeDuplicatingStuff()
    	{
    		_panelPresentatinLogic.DoSomeDuplicatingStuff();
    	}
    }
    
    public class UsageSample
    {
    	public void PopulateCollectionOfItemsDependingOnConfigHopeYouveGotTheIdea()
    	{
    		string configValue = configuration["PanelKind"];
    		PanelPresentatinLogic panelPresentatinLogic = new PanelPresentatinLogic();
    		
    		Panel panel = configValue == "Wrap" 
    			? new SortOfWrapPanel(panelPresentatinLogic)
    			: new SortOfStackPanel(panelPresentatinLogic);
    		// TODO: add panel to GUI
    	}
    }  
