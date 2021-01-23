    [Serializable]
    public class MdsAccordionItemsClass : List<MdsAccordionItem>
    {
    
    }
    
    [Serializable]
    [ParseChildren(true, "MdsAccordionSubMenuItems")]
    [PersistChildren(true)]
    public class MdsAccordionItem : INamingContainer
    {
    	public string Text { get; set; }
    
    	private bool _visible = true;
    	public bool Visible
    	{
    		get { return this._visible; } 
    		set { this._visible = value; }
    	}
    
    	public string Link { get; set; }
    
    	public string ImageUrl { get; set; }
    
    	private MdsAccordionItemsClass _mdsAccordionSubMenuItems;
    
    	[Bindable(true)]
    	[Browsable(false), PersistenceMode(PersistenceMode.InnerProperty)]
    	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    	public MdsAccordionItemsClass MdsAccordionSubMenuItems
    	{
    		get { return _mdsAccordionSubMenuItems ?? new MdsAccordionItemsClass(); }
    		set { _mdsAccordionSubMenuItems = value; }
    	}
    }
