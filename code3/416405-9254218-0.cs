    private UINavigationController navigationController;
    ...
    public override void ViewDidLoad ()
    {
        ...
        var dialogViewController = new DialogViewController(rootElement);
        navigationController = new UINavigationController(dialogViewController);
        View.Add (navigationController.View);
        ...
    }
