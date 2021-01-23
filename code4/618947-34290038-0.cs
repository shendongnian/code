    try
    {
        //  Attempt to set the my VSTO ribbon bar as the active ribbon.
        string controlID = Globals.Ribbons.GetRibbon<MikesRibbon>().MikesTab.ControlId.ToString();
        this.RibbonUI.ActivateTab(controlID);
    }
    catch
    {
    }
