    [ToolboxItemAttribute(false), WebBrowsable(true), WebDescription("Set the list name to use."), WebDisplayName("List Name"), Personalizable(PersonalizationScope.User)]
    public string ListName{ 
        get{return customListName;}
        set{customListName = value;}
    }
