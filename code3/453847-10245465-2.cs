    private void buttons_MouseEnter(object sender, System.EventArgs e)
    {
        Button btn = ((Button)sender);
        hoveredId = (int)btn.Tag;
    }
    
    private void buttons_MouseLeave(object sender, System.EventArgs e)
    {
        Button btn = ((Button)sender);
    
        if ((int)btn.Tag == hoveredId)
            hoveredId = -1;
    }
