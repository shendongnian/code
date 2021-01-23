    private volatile bool _running = true;
    ...
    while (_running)
    {
        // Do stuff
    }
    ...
    public void ButtonClick(object sender, EventArgs e)
    {
        _running = false;
    }
