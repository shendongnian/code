    private void ForceListUpdate(object sender, ICoreWindowEventArgs e)
    {
        if (!Window.Current.Visible)
        {
            DataSource.ForceListUpdate();
        }
    }
