    public MainPage()
    {
        this.InitializeComponent();
        CompositionTarget.Rendering += OnCompositionTargetRendering;
    }
    private void OnCompositionTargetRendering(object sender, object e)
    {
        RenderingEventArgs args = e as RenderingEventArgs;
        double t = (args.RenderingTime.TotalMilliseconds) % 20;
        button1.Margin = new Thickness(t);
    }
