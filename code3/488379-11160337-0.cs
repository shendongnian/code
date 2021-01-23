      protected void btn_edit_Click(object sender, EventArgs e) 
        { 
            using(DatabaseConnector con = new DatabaseConnector().CreateInstance())
            {
              using(SqlCommand com = new SqlCommand("UPDATE tbl_BinCardManager SET ItemName = @ItemName WHERE ItemNo = @ItemNo"))
              {
     
                com.Parameters.Add("@ItemName",sqlDbType.VarChar); 
                con.Open(); 
                cmd.ExecuteNonQuery(); 
              }
            }
         }
