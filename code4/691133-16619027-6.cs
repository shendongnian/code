        void InitGrid()
        {
            gridControl.DataSource = source;
            // Do this after the database for the grid is set!
            selectionHelper = new GridCheckMarksSelection(gridView1);
            // Define where you want the collumn (0 = first)
            selectionHelper.CheckMarkColumn.VisibleIndex = 0;
            // You can even subscrive to the event that indicates that 
            // there was change in the selection.
            selectionHelper.SelectionChanged += selectionHelper_SelectionChanged;
        }
        void selectionHelper_SelectionChanged(object sender, EventArgs e)
        {
            // Do something when the user selects or unselects something
        }
