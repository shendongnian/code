    public Shell()
    {
        InitializeComponent();
        this.Closing += (s,e) =>
        {
            var canClose = Content as ICanClose;
            if (canClose != null)
                e.Cancel = !canClose.CanClose;
        }
    }
