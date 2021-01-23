     DataTable dlcat = new DataTable();
    
            SqlCommand cmdcat = new SqlCommand("select CategoryName from tblCategoryMaster where CategoryMasterSequenceNumber='" + catno + "'", lcon);
            lcon.Open(); 
            cmdcat.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmdcat);
            da.Fill(dlcat);
            dlouter.DataSource = dlcat;
            dlouter.DataBind();
