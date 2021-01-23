    [Serializable]
    public class MdsAccordionMenuItemsClass : List<MdsAccordionMenuItem>
    {
    
    }
    
    [ParseChildren(true, "MdsAccordionItems")]
    [PersistChildren(true)]
    [Serializable]
    public class MdsAccordionMenuItem : INamingContainer
    {
    	public string Title { get; set; }
    
    	private MdsAccordionItemsClass _mdsAccordionItems;
    
    	[Browsable(false), PersistenceMode(PersistenceMode.InnerProperty)]
    	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    	[Bindable(true)]
    	public MdsAccordionItemsClass MdsAccordionItems
    	{
    		get { return _mdsAccordionItems ?? new MdsAccordionItemsClass(); }
    		set { _mdsAccordionItems = value; }
    	}
    }
