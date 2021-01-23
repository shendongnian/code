    public DataSet myObjectDataSource_Select()
    {
       string sqlQuery = "SELECT col1, col2, col3 FROM foo";
       SqlDataAdapter da = new SqlDataAdapter(sqlQuery, myConnectionString);
       DataSet ds = new DataSet();
       using (da) {
            da.Fill(ds);
       }
       //Perform your secondary filtering here
       object [] unfilteredQuery= (from r in ds.Tables[0].AsEnumerable()
            select r.Field<string>(“col1”)).ToArray();
       myUnfilteredComboBox.Items.Clear();
       myUnfilteredComboBox.Items.AddRange(unfilteredQuery);
       return ds;    
    }
