    public MyOuterPage()
    {
        InitializeComponent();
        this.AddHandler(UIElement.MouseLeftButtonDownEvent, new System.Windows.Input.MouseButtonEventHandler(MyMouseLeftButtonDownEventHandler), true);
    }
    void MyMouseLeftButtonDownEventHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var button = e.OriginalSource as Button;
        if (button.Tag == "MyButton")
        {
            // do something with the event here
        }
    }
