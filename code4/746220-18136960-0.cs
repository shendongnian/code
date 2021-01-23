        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _connection.Open();
            try
            {
                DataItemTypeName data = (DataItemTypeName)e.Item.DataItem;
                if (data == null)
                    // This is more of a debugging check, since I'm a little in the dark about data types and such here.
                    throw new Exception("No data.");
                OdbcCommand findempros = new OdbcCommand("SELECT p.projName from projects p INNER JOIN assigns a ON p.projID = a.projname WHERE a.employeeID LIKE '" + data.ID + "'", _connection);
                OdbcDataReader readit = findempros.ExecuteReader();
                while (readit.Read())
                {
                    DropDownList mydblist = (DropDownList)e.Item.FindControl("DropDownList1");
                    mydblist.Items.Add(readit["projName"].ToString());
                }
            }
            finally
            { _connection.Close(); }
        }
