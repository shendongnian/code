     Public BindingSource bs = new BindingSource();
     Public DataTable dt = new DataTable();
    
     SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Name", con);
    
     Con.Open();
     
     da.Fill(dt);
    
     Con.Close();
     
     bs.DataSource = dt;
    
     dataGridview1.DataSource = bs;
