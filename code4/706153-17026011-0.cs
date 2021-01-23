    //Class-level variables
    private DataGridView _gridView;
    public void create_Tab_Control()
    {
        //Logic to create the Tabs
        _gridView = new DataGridView();
        //Add the DataGridView to the TabControl
    }
    public void add_row()
    {
        //Add the row(s) to the DataGridView
        _gridView.Rows.Add("column 1", "column 2");
    }
