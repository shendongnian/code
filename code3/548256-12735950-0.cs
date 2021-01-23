    private void grid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        UltraGridCell currentCell = null;
        grid.ContextMenu = null;
        if (e.Button == MouseButtons.Right)
        {
            Point ulPoint = new Point(e.X, e.Y);
            UIElement el = grid.DisplayLayout.UIElement.ElementFromPoint(ulPoint); 
            if (el != null)
                currentcell = (UltraGridCell)el.GetContext(typeof(UltraGridCell)); 
            if (currentcell != null && currentCell.Row.IsDataRow == true)
            {
                grid.ActiveCell = currentcell;
                grid.ContextMenu = menuPopup;
            }
        }
    }
