    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
        GridView view = (GridView)sender;    
        Point pt = view.GridControl.PointToClient(Control.MousePosition);    
    }
