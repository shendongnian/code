    bool bKeyIsDown = false;
    Keys currentKey = Keys.None;
    public event EventHandler OnKeyPressedOnce;
    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (bKeyIsDown && currentKey == e.KeyCode)
            e.SuppressKeyPress = true;
        else
        {
            currentKey = e.KeyCode;       
            //have your class handle this event and play the sound when this fires    
            //Could also create custom EventArgs and pass the key pressed 
            if(OnKeyPressedOnce != null)
               OnKeyPressedOnce(null, EventArgs.Empty);
            bKeyIsDown = true;
        }
        base.OnKeyDown(e);
    }
  
    protected override void OnKeyUp(KeyEventArgs e)
    {
        bKeyIsDown = false;
        base.OnKeyUp(e);
    }
