    Windows.UI.Input.GestureRecognizer gr = new Windows.UI.Input.GestureRecognizer();  
    
    public MainPage()
    {
        this.InitializeComponent();
        this.PointerPressed += MainPage_PointerPressed;
        this.PointerMoved += MainPage_PointerMoved;
        this.PointerReleased += MainPage_PointerReleased;
        gr.CrossSliding += gr_CrossSliding;    
        gr.Dragging += gr_Dragging;    
        gr.Holding += gr_Holding;    
        gr.ManipulationCompleted += gr_ManipulationCompleted;    
        gr.ManipulationInertiaStarting += gr_ManipulationInertiaStarting;    
        gr.ManipulationStarted += gr_ManipulationStarted;    
        gr.ManipulationUpdated += gr_ManipulationUpdated;    
        gr.RightTapped += gr_RightTapped;    
        gr.Tapped += gr_Tapped;    
        gr.GestureSettings = Windows.UI.Input.GestureSettings.ManipulationRotate | Windows.UI.Input.GestureSettings.ManipulationTranslateX | Windows.UI.Input.GestureSettings.ManipulationTranslateY |    
        Windows.UI.Input.GestureSettings.ManipulationScale | Windows.UI.Input.GestureSettings.ManipulationRotateInertia | Windows.UI.Input.GestureSettings.ManipulationScaleInertia |    
        Windows.UI.Input.GestureSettings.ManipulationTranslateInertia | Windows.UI.Input.GestureSettings.Tap; 
    }
    void MainPage_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        var ps = e.GetIntermediatePoints(null);
        if (ps != null && ps.Count > 0)
        {
            gr.ProcessUpEvent(ps[0]);
            e.Handled = true;
            gr.CompleteGesture();
        }
    }
    void MainPage_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        gr.ProcessMoveEvents(e.GetIntermediatePoints(null));
        e.Handled = true;
    }
    void MainPage_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        var ps = e.GetIntermediatePoints(null);
        if (ps != null && ps.Count > 0)
        {
            gr.ProcessDownEvent(ps[0]);
            e.Handled = true;
        }
    }
