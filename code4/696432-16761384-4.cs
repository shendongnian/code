    if ((e.KeyCode == System.Windows.Forms.Keys.LControlKey) || (e.KeyCode == System.Windows.Forms.Keys.RControlKey))
    {
        controlDown = true;
    }
    if (e.KeyCode == System.Windows.Forms.Keys.M && controlDown)
    {
        // Do CTRL-M action
    }
