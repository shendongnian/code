    private void lbxItems_MouseMove(object sender, MouseEventArgs e)
    {
        if (Control.ModifierKeys == Keys.Alt && e.Button == MouseButtons.Left) 
        {
            lbxItems.DoDragDrop("Copy Text 1", DragDropEffects.Copy);
        }
        else if (e.Button == MouseButtons.Left) 
        {
            lbxItems.DoDragDrop("Copy Text 2", DragDropEffects.Copy);
        }
    }
