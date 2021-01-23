      private void frmDgv_SearchResult_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from Measurement", con);
            da.Fill(ds, "Measurement");
            dt = ds.Tables["Measurement"];
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
           
            cb.GetInsertCommand();
            cb.GetUpdateCommand();
            cb.GetDeleteCommand();
    
            cb.ConflictOption = ConflictOption.CompareAllSearchableValues;
        }
