        protected void BtnUserNext_Click(object sender, EventArgs e)
        {
        SqlCon.Open();
        SqlCommand cmd2 = new SqlCommand("usp_User_Info3", SqlCon);
        cmd2.CommandType = CommandType.StoredProcedure;
        cmd2.CommandText = "usp_User_Info3";
        System.Data.SqlClient.SqlParameter SNo=cmd2.Parameters.Add("@SNo", System.Data.SqlDbType.Int);
        cmd2.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text.Trim();
        cmd2.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = txtRegPassword.Text.Trim();
        cmd2.Parameters.Add("@User_ConPassword", SqlDbType.VarChar).Value = txtRegConPassword.Text;
        cmd2.Parameters.Add("@User_FirstName", SqlDbType.VarChar).Value = txtRegFName.Text.Trim();
        cmd2.Parameters.Add("@User_LastName", SqlDbType.VarChar).Value = txtRegLName.Text.Trim();
        cmd2.Parameters.Add("@User_Title", SqlDbType.VarChar).Value = txtRegTitle.Text.Trim();
        cmd2.Parameters.Add("@User_OtherEmail", SqlDbType.VarChar).Value = txtOtherEmail.Text.Trim();
        cmd2.Parameters.Add("@User_PhoneNo", SqlDbType.VarChar).Value = txtRegCode1.Text;
        cmd2.Parameters.Add("@User_MobileNo", SqlDbType.VarChar).Value = txtRegCode2.Text;
        cmd2.Parameters.Add("@User_FaxNo", SqlDbType.VarChar).Value = txtRegCode3.Text;
        cmd2.Connection = SqlCon;
        try
        {
           SNo.Direction = System.Data.ParameterDirection.Output;
           cmd2.ExecuteScalar();
           string VendorID = "VEN" + cmd2.Parameters["@SNo"].Value.ToString();
        }
        finally
        {
        string url = "../CompanyBasicInfo.aspx?Parameter=" + Server.UrlEncode(" + VendorID + ");
        ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Login created successfully');window.location.href = '" + url + "';", true);
         SqlCon.Close();
         }
        }
