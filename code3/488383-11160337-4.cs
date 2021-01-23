    public static CONN_STR = "Data Source=lernlap;Initial Catalog=ERPSystemDB;User ID=sa;Password=sa123";
      protected void btn_edit_Click(object sender, EventArgs e) 
        { 
            using(SqlConnection con = new SqlConnection(CONN_STR))
            {
              con.Open(); 
              using(SqlCommand cmd = new SqlCommand("UPDATE tbl_BinCardManager SET ItemName = @ItemName WHERE ItemNo = @ItemNo"), con)
              {
     
                cmd.Parameters.Add("@ItemName",sqlDbType.VarChar); 
                cmd.ExecuteNonQuery(); 
              }
            }
         }
