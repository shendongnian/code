      protected void btn_edit_Click(object sender, EventArgs e) 
        { 
            // if DatabaseConnector implements IDisposable, it will need a using statement around it
            DatabaseConnector dbc = new DatabaseConnector().CreateInstance();
            using(SqlConnection con = dbc.GetConnectionObject())
            {
              con.Open(); 
              using(SqlCommand cmd = new SqlCommand("UPDATE tbl_BinCardManager SET ItemName = @ItemName WHERE ItemNo = @ItemNo"), con)
              {
     
                cmd.Parameters.Add("@ItemName",sqlDbType.VarChar); 
                cmd.ExecuteNonQuery(); 
              }
            }
         }
