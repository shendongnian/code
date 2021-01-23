    SqlDataAdapter DA = new SqlDataAdapter("Search_Student",
            DBConnection.GetConnection());
        DA.SelectCommand.CommandType = CommandType.StoredProcedure;                    
    
    
         SqlParameter param  = new SqlParameter();
         param.ParameterName = "@FirstName";
          param.Value  = txtName.Text;
    
    
        DA.SelectCommand.Parameters.Add(param);
    
        DataTable DA1 = new DataTable();
        DA.Fill(DA1);
        dataGridView1.DataSource = DA1;
