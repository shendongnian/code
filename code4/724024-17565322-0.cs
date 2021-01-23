    private void glControl1_MouseHover(object sender, EventArgs e)
    {
        Control control = sender as Control;
        Point pt = control.PointToClient(Control.MousePosition);
    }
