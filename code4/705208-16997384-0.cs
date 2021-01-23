    ListView lv = new ListView
        {
            Top = 200, 
            Left = 10, 
            Width = 300, 
            Height = 300,
            View = View.Details 
        };
    
    lv.Columns.Add(
        new ColumnHeader {Name = "ch1", Text = "col1"});
    lv.Columns.Add(
        new ColumnHeader { Name = "ch2", Text = "col2" });
    
    lv.Items.Add(
        new ListViewItem(new string[] {"r1c1","r1c2"}));
    lv.Items.Add(
        new ListViewItem(new string[] { "r2c1", "r2c2" }));
    
    this.Controls.Add(lv);
