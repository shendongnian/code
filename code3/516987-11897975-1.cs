    //Override the default factory method (just made this up)
    public override Presenter GetPresenter(Type presenterType)
    {
        return ComponentFactory.GetInstance(presenterType);
    }
