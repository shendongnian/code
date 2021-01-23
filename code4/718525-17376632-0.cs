    SqlConnection conn = new SqlConnection("my working connection string");
    SqlDataAdapter adapter = new SqlDataAdapter("Select * from Customers", conn);
    DataSet ds = new DataSet();
    // Create command builder. This line automatically generates the update commands for you, so you don't 
    // have to provide or create your own.
    SqlCommandBuilder mySqlCommandBuilder = new SqlCommandBuilder(adapter);
    // Set the MissingSchemaAction property to AddWithKey because Fill will not cause primary
    // key & unique key information to be retrieved unless AddWithKey is specified.
    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    adapter.Fill(ds, "Customers");
  
    // .... Code to fill the picArray....
 
    DataRow row = ds.Tables[0].NewRow();
    row["Id"] = "ID";
    row["Name"] = "NAME";
    row["Picture"] = picArray;
    ds.Tables["Customers"].Rows.Add(row);
    adapter.Update(ds, "Customers"); //Update the changes to the database
