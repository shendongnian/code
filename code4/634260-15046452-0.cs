    bool isAPressed;
    ...
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        switch(e.KeyCode)
        {
            case Key.A:
                isAPressed = true;
                break;
            case Key.XXXX:
                ...
        }
    }
    
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        switch(e.KeyCode)
        {
            case Key.A:
                isAPressed = false;
                break;
            case Key.XXXX:
                ...
        }
    }
