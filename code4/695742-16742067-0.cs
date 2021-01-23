    var pids = string.Join(",", PID); //this will create one string with every element
                                      //in the array seperated by ','
    
    
    string firstQuery = "select * from Property p " +
                                "where p.id in (@pID)";
    connString.Open();
    SqlCommand selectAll = new SqlCommand(firstQuery, connString);
    selectAll.Parameters.AddWithValue("@pID", pids);
    SqlDataAdapter adapter = new SqlDataAdapter();
    adapter.SelectCommand = selectAll;
    DataSet ds = new DataSet();
    adapter.Fill(ds);
    connString.Close();
    DataTable table = ds.Tables[0];
