    //MouseUp EventHandler ---------
    static void MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        MMove = false;
        MyControl = null;
        System.Windows.Input.Mouse.Capture(null);
    }
