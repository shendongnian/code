    private void ConnectionHasChanged(object sender, ConnectionChangeEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() =>
            {
                ConnectionHasChanged(sender, e);
            }));
            return;
        }
        if (e.ConnectionType == ConnectionType.Network)
        {
            ...
