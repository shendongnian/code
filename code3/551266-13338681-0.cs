          private void CallImage()
          {
           SqlConnection SqlCon = new SqlConnection(GetConnectionString());
           SqlCon.Open();
           string query = "SELECT FilePath FROM CompanyInfo 
                  WHERE VendorID= '" + ddlVendorID.SelectedValue + "'";
           SqlCommand SqlCmd = new SqlCommand(query, SqlCon);
           SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
           DataTable dt = new DataTable();
           da.Fill(dt);
           string ImageName = Convert.ToString(dt.Rows[0][0].ToString());
           Image1.ImageUrl = ("~\\Upload\\Commerical Certificates\\" + ImageName);
           SqlCon.Close();
         }
