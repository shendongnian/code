    private void canvasNote_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var canvas = (Canvas)sender;
        var title = canvas.Children.OfType<TextBlock>().First(t => (t.Tag as string) == "Title");
        System.Diagnostics.Debug.WriteLine(title.Text);
    }
