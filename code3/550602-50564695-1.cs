    DateTime sw;
    bool buttonUp = false;
    const int holdButtonDuration = 2000;
    private void btnTest_MouseDown(object sender, MouseEventArgs e)
    {
        buttonUp = false;
        sw = DateTime.Now; //Stopwatch sw = new Stopwatch(); sw.Start();
        while (e.Button == MouseButtons.Left && e.Clicks == 1 && (buttonUp == false && (DateTime.Now - sw).TotalMilliseconds < holdButtonDuration)) //&& sw.ElapsedMilliseconds < holdButtonDuration))
            Application.DoEvents();
        if ((DateTime.Now - sw).TotalMilliseconds < holdButtonDuration) //if (sw.ElapsedMilliseconds < holdButtonDuration)
            chkShortClick.Checked = !chkShortClick.Checked; //btnTest_ShortClick();
        else
            chkLongClick.Checked = !chkLongClick.Checked; //btnTest_LongClick();
    }
    private void btnTest_MouseUp(object sender, MouseEventArgs e)
    {
        buttonUp = true;
    }
