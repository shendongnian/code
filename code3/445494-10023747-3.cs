    private bool _keyPressed;
    
    private void TimerElapsed(object sender, EventArgs e)
    {
        if (!_keyPressed)
        {
            // do what you need
        }
    }
    
    private void KeyDownHandler(object sender, KeyEventArgs e)
    {
        _keyPressed = true;
    
        switch (e.KeyCode)
        {
            // process pressed key
        }
    
        _keyPressed = false;
    } 
