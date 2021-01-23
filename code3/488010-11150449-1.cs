    //Define different context menus for different columns
    private ContextMenu contextMenuForColumn1 = new ContextMenu();
    private ContextMenu contextMenuForColumn2 = new ContextMenu();
    
    Add the following line of code in the form load event:
    
    private void Form_Load(object sender, EventArgs e)
    {
        // Load all default values of controls 
        populateDataGridView();
    
        // Add context mneu items
        contextMenuForColumn1.MenuItems.Add("Make Active", new     EventHandler(MakeActive));
        contextMenuForColumn2.MenuItems.Add("Delete", new     EventHandler(Delete));
        contextMenuForColumn2.MenuItems.Add("Register", new     EventHandler(Register));
    }
    
    Add the following code to mouseup event of the gridview:
    
    private void dataGridView_MouseUp(object sender, MouseEventArgs e)
    {
        // Load context menu on right mouse click
        DataGridView.HitTestInfo hitTestInfo;
        if (e.Button == MouseButtons.Right)
        {
            hitTestInfo = dataGridView.HitTest(e.X, e.Y);
            // If column is first column
            if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == 0)
                contextMenuForColumn1.Show(dataGridView, new Point(e.X, e.Y));
            // If column is second column
            if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.ColumnIndex == 1)
                contextMenuForColumn2.Show(dataGridView, new Point(e.X, e.Y));
        }
    } 
