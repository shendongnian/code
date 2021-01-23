    private Keys lastKeyPressed = null;
    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if(e.Control && lastKeyPressed != null)
        {
            if(lastKeyPressed == Keys.firstKey && e.KeyCode == Keys.secondKey)
            {
            }
            else if (...) // so on and so forth.
        }
        else if(e.Control)
            lastKeyPressed = e.KeyCode;
    }
    protected override void OnKeyUp(KeyEventsArgs e)
    {
        if(!e.Control)
           lastKeyPressed = null;
    }
