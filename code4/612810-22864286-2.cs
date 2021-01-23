    var object m_LockObject = new Object();
    private async void OnMessageReceived(object sender, EventArgs e)
    {
        // Does not work
        Monitor.Enter(m_LockObject);
        await Task.Run(() => this.model.Apply(e));
        Monitor.Exit(m_LockObject);
    }
