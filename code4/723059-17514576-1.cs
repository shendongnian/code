    private void canvasNote_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var canvas = (Canvas)sender;
        var title = (TextBlock)canvas.FindName("Title");
        System.Diagnostics.Debug.WriteLine(title.Text);
    }
