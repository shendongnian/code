    using System.Reactive;
    public MainWindow()
    {
        InitializeComponent();
        Observable.Interval(TimeSpan.FromSeconds(1))
            .Subscribe( _ => Checking() );
    }
