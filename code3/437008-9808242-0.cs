        PageLoad(...)
        {
            BuildTable();
        }
        BuildTable()
        {
            phTable.Controls.Clear();
            Table T = new Table();
             //do stuff
            phTable.Controls.Add(T);
    
    
        }
        protected void remove_Click(object sender, EventArgs e)
        {
            //remove record from database
            BuildTable();
    
        }
