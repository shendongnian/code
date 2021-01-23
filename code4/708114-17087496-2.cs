    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
        DataContext = LoadModel();
        base.LoadState(navigationParameter, pageState);
    }
