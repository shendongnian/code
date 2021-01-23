    private void slider1_DragCompleted(object sender,     
        System.Windows.Controls.Primitives.DragCompletedEventArgs e)
    {
        var realPosition = TimeSpan.FromSeconds(slider1.Value);
        foreach (var elem in videos)
        {
            elem.Position = realPosition;
        }
        foreach (var elem in videos)
        {
            elem.Play();
        }
