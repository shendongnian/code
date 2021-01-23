    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        token = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUsername.Text.ToString() + txtAcctNo.Text.ToString(), "MD5");
        try
        {
            bool isExist = false;
            DataSet ds = new DataSet();
            ds = startService.getAllUsersWithoutFilter();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dRow in ds.Tables[0].Rows)
                {
                    string userName = dRow["UserName"].ToString();
                    string acctNo = dRow["AccountNumber"].ToString();
                    string question = dRow["SecretQuestion"].ToString();
                    string answer = dRow["SecretAnswer"].ToString();
                    if (userName == txtUsername.Text.ToString() && acctNo == txtAcctNo.Text.ToString() && question == cboQuestion.Text.ToString() &&  answer == txtAnswer.Text.ToString())
                    {
                         // if exist execute following code
                        startService.sendTokenizer(txtUsername.Text.ToString(), token);
                    //update database to change password to standard password
                    startService.inserUserActivity(txtUsername.Text.ToString(), txtAcctNo.Text.ToString(), "Password Reset Request", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                    startService.requestReset(txtUsername.Text.ToString(), txtAcctNo.Text.ToString(), token);
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "<br>We have sent an email to you for the instructions to reset your password. Please check your email.";
                    }
                    else
                    {
                      // id not exist then execute following code
                       this.lblMessage.ForeColor = System.Drawing.Color.Red;
                    this.lblMessage.Text = "<br><br>Error - Information cannot be found. Please check and try again. Make sure all the fields are correct.";
                    }
                }              
            }
        }
        catch
        {
            lblError.Text = "There was an error occured while processing your request. Please try again later.";
        }
    }
