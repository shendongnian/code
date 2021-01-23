    protected void SendToServer_Click(object sender, EventArgs e)
    {
        DataTable Values = Session["valuesdt"] as DataTable ;
        if(Values.Rows.Count>0)
        {
            DataTable dv = Values.DefaultView.ToTable(true, "Mobile1", "Mobile2", "Tel", "Category");
            //Fix up default values
            for (int i = 0; i < Values.Rows.Count; i++)
           {
                Values.Rows[i]["Mobile1"] =Values.Rows[i]["Mobile1"].ToString()==""?0: double.Parse(Values.Rows[i]["Mobile1"].ToString());
                Values.Rows[i]["Mobile2"] = Values.Rows[i]["Mobile2"].ToString() == "" ? 0 : double.Parse(Values.Rows[i]["Mobile2"].ToString());
                Values.Rows[i]["Tel"] = Values.Rows[i]["Tel"].ToString() == "" ? 0 : double.Parse(Values.Rows[i]["Tel"].ToString());
    
               Values.Rows[i]["Category"] = Values.Rows[i]["Category"].ToString();
           }
           BatchUpdate(dv,1000);
    
    
        }
    
    }
    public static void BatchUpdate(DataTable dataTable,Int32 batchSize)
    {
        // Assumes GetConnectionString() returns a valid connection string.
        string connectionString = GetConnectionString();
    
        // Connect to the database.
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
    
            // Create a SqlDataAdapter.
            SqlDataAdapter adapter = new SqlDataAdapter();
    
            // Set the INSERT command and parameter.
            adapter.InsertCommand = new SqlCommand(
                "INSERT INTO client(Mobile1,Mobile2,Tel,Category) VALUES(@Mobile1,@Mobile2,@Tel,@Category);", connection);
            adapter.InsertCommand.Parameters.Add("@Mobile1", 
              SqlDbType.Float);
            adapter.InsertCommand.Parameters.Add("@Mobile2", 
              SqlDbType.Float);
            adapter.InsertCommand.Parameters.Add("@Tel", 
              SqlDbType.Float);
            adapter.InsertCommand.Parameters.Add("@Category", 
              SqlDbType.NVarchar, 50);
            adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
    
            // Set the batch size.
            adapter.UpdateBatchSize = batchSize;
    
            // Execute the update.
            adapter.Update(dataTable);
        }
    }
