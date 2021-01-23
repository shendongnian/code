    DateTime sw;
    bool buttonUp = false;
    const int holdButtonDuration = 2000;
    private void btnTest_MouseDown(object sender, MouseEventArgs e)
    {
        buttonUp = false;
        sw = DateTime.Now;
        while (e.Button == MouseButtons.Left && e.Clicks == 1 && (buttonUp == false && (DateTime.Now - sw).TotalMilliseconds < holdButtonDuration))
            Application.DoEvents();
        if ((DateTime.Now - sw).TotalMilliseconds < holdButtonDuration)
            Test_ShortClick();
        else
            Test_LongClick();
    }
    private void btnTest_MouseUp(object sender, MouseEventArgs e)
    {
        buttonUp = true;
    }
