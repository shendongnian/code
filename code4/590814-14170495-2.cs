    public MainWindow(IMainWindowViewModel viewModel, 
         Func<SubView1> subView1Factory)
    public SubView1(ISubView1Model viewModel,
        IFooService fooService,
        Func<IFooService, SubView2> subView2Factory)
    public SubView2(
        ISubView2ModelViewModel viewModel, 
        IBarService barService)
