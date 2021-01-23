    private UserActivityHook _actHook;
    private void MainFormLoad(object sender, System.EventArgs e)
    {
        _actHook = new UserActivityHook();
    
        _actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
    }
