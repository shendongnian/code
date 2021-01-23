    public MainPage()
    {
        this.InitializeComponent();
    
        this.MyMap.PointerPressedOverride += MyMap_PointerPressedOverride;
    }
    
    void MyMap_PointerPressedOverride(object sender, PointerRoutedEventArgs e)
    {
        Bing.Maps.Location l = new Bing.Maps.Location();
        this.MyMap.TryPixelToLocation(e.GetCurrentPoint(this.MyMap).Position, out l);
        Bing.Maps.Pushpin pushpin = new Bing.Maps.Pushpin();
        pushpin.SetValue(Bing.Maps.MapLayer.PositionProperty, l);
        this.MyMap.Children.Add(pushpin);
    }
