    [ToolboxData("<{0}:MdsAccordionMenu runat=server></{0}:MdsAccordionMenu>")]
    [ParseChildren(true, "MdsAccordionMenuItems")]
    [DefaultProperty("MdsAccordionMenuItems")]
    [PersistChildren(true)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public sealed class MdsAccordionMenu : WebControl, INamingContainer
    {
    	#region Properties
    
    	public int AnimationSpeed { get; set; }
    
    	public string InlineStyle { get; set; }
    
    	[Bindable(true)]
    	[Browsable(false), PersistenceMode(PersistenceMode.InnerProperty)]
    	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    	public MdsAccordionMenuItemsClass MdsAccordionMenuItems
    	{
    		get { return _mdsAccordionMenuItem ?? new MdsAccordionMenuItemsClass(); }
    		set { _mdsAccordionMenuItem = value; }
    	}
    
    	private MdsAccordionMenuItemsClass _mdsAccordionMenuItem;
    }
