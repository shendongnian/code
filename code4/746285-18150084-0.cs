    public string VlcUrl
    {
        get { return (string)GetValue(VlcUrlProperty); }
        set { SetValue(VlcUrlProperty, value); }
    }
    public static readonly DependencyProperty VlcUrlProperty =
            DependencyProperty.Register("VlcUrl", typeof(string), typeof(VlcPlayer), new PropertyMetadata(null, OnVlcUrlChanged));
    private static void OnVlcUrlChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var player = obj as VlcPlayer;
        if (obj == null)
           return;
      
        obj.ChangeVlcUrl(e.NewValue);
    }
    private void ChangeVlcUrl(string newUrl)
    {
        //do stuff here
    }
