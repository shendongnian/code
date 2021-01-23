    MySettings settings = new MySettings();
    textBox1.Enabled = settings.ShouldTextBoxBeEnabled();
    // Or static way
    textBox1.Enabled = MySettings.StaticShouldTextBoxBeEnabled;
    // Or this way you can send in all textboxes you want to do the logic on.
    MySettings.SetTextBoxState(textBox1);
