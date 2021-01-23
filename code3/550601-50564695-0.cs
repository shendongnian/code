    bool buttonUp = false;
    const int holdButtonDuration = 2000;
    private void btnTest_MouseDown(object sender, MouseEventArgs e)
    {
        buttonUp = false;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        while (e.Button == MouseButtons.Left && e.Clicks == 1 && (buttonUp == false && sw.ElapsedMilliseconds < holdButtonDuration))
            Application.DoEvents();
        if (sw.ElapsedMilliseconds < holdButtonDuration)
            chkShortClick.Checked = !chkShortClick.Checked; //btnTest_ShortClick();
        else
            chkLongClick.Checked = !chkLongClick.Checked; //btnTest_LongClick();
    }
    private void btnTest_MouseUp(object sender, MouseEventArgs e)
    {
        buttonUp = true;
    }
