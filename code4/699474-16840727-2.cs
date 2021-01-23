    private DynamicTitleProvider provider;
    public override string Title
        {
            get { return provider.GetTitle(); }
        }
