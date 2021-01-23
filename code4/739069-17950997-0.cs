     protected void btnSumbit_Click(object sender, EventArgs e)
            {       
                //call some function to verify IP entered by user
                bool isExistingIp = VerifyIp(txtIP.Text); 
                if (isExistingIp)
                {
                    // event argument PASSED when user confirm to override from client side
                    string isoverride = Request.Form["__EVENTARGUMENT"]; 
                    if (string.IsNullOrEmpty(isoverride))
                    {                
                        //register script if user hasn't confirmed yet
                        this.ClientScript.RegisterStartupScript(this.GetType(), "displaywarning", "displaywarning();", true);
                        Page.GetPostBackEventReference(btnSumbit);
                    }
                    else
                    {
                        //continue with functionality
                    }
                   
                }
                else
                {
                    //continue with functionality
                }
            }
