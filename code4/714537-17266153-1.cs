    _thumbButtonManager = this.CreateThumbButtonManager();
    ThumbButton button2 = _thumbButtonManager.CreateThumbButton(102, SystemIcons.Exclamation, "Beware of me!");
    button2.Clicked += delegate
    {
        statusLabel.Text = "Second button clicked";
        button2.Enabled = false;
    };
    ThumbButton button = _thumbButtonManager.CreateThumbButton(101, SystemIcons.Information, "Click me");
    button.Clicked += delegate
    {
        statusLabel.Text = "First button clicked";
        button2.Enabled = true;
    };
    _thumbButtonManager.AddThumbButtons(button, button2);
    Note that you have tooltips and icons at your disposal to personalize the thumbnail toolbar to your application’s needs.  All you need to do now is override your windows’ window procedure and call the DispatchMessage method of the ThumbButtonManager, so that it can correctly route the event to your registered event handlers (and of course, don’t forget to call the default window procedure when you’re done!):
    
    if (_thumbButtonManager != null)
        _thumbButtonManager.DispatchMessage(ref m);
     
    base.WndProc(ref m);
