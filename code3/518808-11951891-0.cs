    partial void ScreenName_InitializeDataWorkspace(List<IDataService> saveChangesTo)
    {
        this.FindControl("SecondCustomControl").IsVisible = False;
    }
    
    partial void ButtonName_Execute()
    {
        this.FindControl("SecondCustomControl").IsVisible = True;
    }
