    protected void btnGoodAddShipper_Click(object sender, EventArgs e)
    {
       string connStr = c
          "Server=(local);Database=Northwind;Integrated Security=SSPI";
            
       // this is good because all input becomes a
       // parameter and not part of the SQL statement
       string cmdStr =
          "insert into Shippers (CompanyName, Phone) values (" +
          "@CompanyName, @Phone)";
     
       using (SqlConnection conn = new SqlConnection(connStr))
          using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
             {
                 // add parameters
                 cmd.Parameters.AddWithValue
                    ("@CompanyName", txtCompanyName.Text);
                 cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
     
                 conn.Open();
                 cmd.ExecuteNonQuery();
             }
    }
