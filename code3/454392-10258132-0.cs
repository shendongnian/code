    public event EventHandler SomethingHappened;
    private void OnMouseDown(object sender, MouseEventArgs e) {
        OnSomethingHappened(e);
    }
    private void OnSomethingHappened(EventArgs args) {
        var handler = SomethingHappened;
        if (handler != null)
            handler(this, args);
    }
