    private static void OnVisibleChanged(object sender, EventArgs e)
    {
        var customTaskPane = sender as CustomTaskPane;
        if (customTaskPane != null)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => { customTaskPane.Visible = true; }));
        }
    }
