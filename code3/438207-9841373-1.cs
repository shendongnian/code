    private void btnToggleBUserControlVisibility_Click(object sender, EventArgs e)
    {
        // reset the stopwatch because we just clicked it
        _sinceLastMouseClick.Restart();
        myUserControl1.Visible = !myUserControl1.Visible;
    }
