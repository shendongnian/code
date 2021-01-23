      protected void btn_edit_Click(object sender, EventArgs e) 
        { 
            // if DatabaseConnector implements IDisposable, it will need a using statement around it
            DatabaseConnector dbc = new DatabaseConnector().CreateInstance();
            using(SqlConnection con = dbc.GetConnectionObject())
            {
              using(SqlCommand com = new SqlCommand("UPDATE tbl_BinCardManager SET ItemName = @ItemName WHERE ItemNo = @ItemNo"), con)
              {
     
                com.Parameters.Add("@ItemName",sqlDbType.VarChar); 
                con.Open(); 
                cmd.ExecuteNonQuery(); 
              }
            }
         }
