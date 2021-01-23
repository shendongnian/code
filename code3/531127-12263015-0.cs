    protected void BtnHomeUserSubmit_Click(object sender, EventArgs e)
       {
        SqlConnection SqlCon = new SqlConnection(GetConnectionString());
        try
        {          
            var da1 = new SqlDataAdapter
               ("select * from User_Info2 where Vendor_ID ='" +   txtHomeUsername.Text.Trim() + "'
       AND User_Password='" + txtHomePassword.Text.Trim() + "'", SqlCon);
       var dt1 = new DataTable();
       da1.Fill(dt1);
       if (dt1.Rows.Count == 0)
       {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert",
            "alert('Enter valid Vendor ID and Password');", true);
       }
      else
      {
         var da2 = new SqlDataAdapter
          ("select * from Company_Info where Vendor_ID='"+ txtHomeUsername.Text+"' 
          AND (Approval_Status='NO' OR Approval_Status='PEN')", SqlCon);
          var dt2 = new DataTable();
          da2.Fill(dt2);
          if (dt2.Rows.Count > 0)
         {
               string url = "../ApprovalStatus2.aspx?Parameter=" +
                     Server.UrlEncode(txtHomeUsername.Text);
                     ClientScript.RegisterStartupScript(this.GetType(),
                    "callfunction","alert('Vendor ID is waiting for Approval');
                  window.location.href = '" + url + "';", true);
          }
          else
         {
                 var da3 = new SqlDataAdapter
                ("select Vendor_ID from RegPage1 where Vendor_ID='" + 
                  txtHomeUsername.Text.Trim() + "'",SqlCon);
                var dt3 = new DataTable();
                da3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                     string url = "../UserLogin.aspx";
                     ClientScript.RegisterStartupScript(this.GetType(),"callfunction",
                     "alert('Vendor ID already completed the 
                      registration');window.location.href ='" + url + "';", true);
                 }
                 else
                 {
                      Response.Redirect("~/RegPage1.aspx?Parameter=" + 
                      Server.UrlEncode(txtHomeUsername.Text));
                 }
           }
      }
      }
      finally
      {
      SqlCon.Close();
      }
