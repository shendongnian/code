    private static bool _loaded = false;
    private void OnLoaded(object sender, EventArgs e)
    {
        if(_loaded == false)
        {
            // do work
            _loaded = true;
        }
    }
