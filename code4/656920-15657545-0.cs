    private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) {
            FormMouseDownLocation = e.Location;
            toolStrip1.Capture = true;
        }
    }
    private void toolStrip1_MouseUp(object sender, MouseEventArgs e)
    {
        toolStrip1.Capture = false;
    }
