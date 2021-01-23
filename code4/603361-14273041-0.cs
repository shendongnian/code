    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var _TextParam = e.Parameter.ToString();
        this.MyTopBarControl.MyText = _TextParam;
    }
