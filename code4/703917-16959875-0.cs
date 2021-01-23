    protected override void LoadViewState(object savedState)
    {
        log.WriteLog("Drawing the menu");
        if (IsPostBack)
        {
            drawMenu();
        }
        base.LoadViewState(savedState);
    }
