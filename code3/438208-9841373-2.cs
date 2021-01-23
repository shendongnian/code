    private void myUserControl1_Leave(object sender, EventArgs e)
    {
        // see if the mouse is over the toggle button
        Point ptMouse = System.Windows.Forms.Control.MousePosition;
        Point ptClient = this.PointToClient(ptMouse);
        // if the mouse is NOT hovering over the toggle button and has NOT just clicked it,
        // then keep the focus in the user control.
        // We use the stopwatch to make sure that not only are we hovering over the button
        // but that we also clicked it, too
        if (btnToggleBUserControlVisibility != this.GetChildAtPoint(ptClient) ||
            _sinceLastMouseClick.ElapsedMilliseconds > 100)
        {
            myUserControl1.Focus();
        }
    }
