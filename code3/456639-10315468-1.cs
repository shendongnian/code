    void OnEvent(object sender, EventArgs args)
    {
        // runs in the event sender's thread
        string x = ComputeChanges(args);
        Dispatcher.BeginInvoke((Action)(
            () => UpdateUI(x)
        ));
    }
    void UpdateUI(string x)
    {
        // runs in the UI thread
        control.Content = x;
        // - or -
        new DialogWindow() { Content = x, Owner = this }.ShowDialog();
        // - or whatever
    }
