    // initialize once (use the designer)
    ListView lv = new ListView
        {
            Top = 200, 
            Left = 10, 
            Width = 300, 
            Height = 300,
            View = View.Details // this does the trick for multiple columns
        };
    // add two Columns in the designer
    lv.Columns.Add(
        new ColumnHeader {Name = "ch1", Text = "Lastname"});
    lv.Columns.Add(
        new ColumnHeader { Name = "ch2", Text = "Id" });
    
                this.Controls.Add(lv);
                
    // once you have that you can add ListViewItems to the view
    using (var myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
    {
        myDatabaseConnection.Open();
        using (var SqlCommand = new SqlCommand("Select ID, LastName from Employee", myDatabaseConnection))
        {
            var dr = SqlCommand.ExecuteReader();
            while (dr.Read())
            {
                // listBox1.Items.Add((string)dr["LastName"] + "\t\t" + dr["ID"]);
                lv.Items.Add(new ListViewItem(new string[] { dr["LastName"], dr["ID"] }));
            }
        }
    }
