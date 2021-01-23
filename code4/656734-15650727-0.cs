    // ListItem is appropriately serializable and works well for
    // automatic binding to various list controls.
    List<ListItem> Names {
        // May return null
        get { return (List<ListItem>)ViewState["names"]; }
        set { ViewState["names"] = value; }
    }
