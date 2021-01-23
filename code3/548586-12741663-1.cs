    private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        Dispatcher.BeginInvoke(new Action(EditStoryBoard), DispatcherPriority.Normal);
    }
    private void EditStoryBoard()
    {
        var gsb = (Storyboard) GameCanvas.FindResource("GameStoryBoard");
        gsb.Children.Clear();
    }
