       void GetUser(string EmployeeName, string Password)
        {
            SqlConnection con2 = new SqlConnection(connstring);
            string cmd1 = "select Emp_IsBlocked from dbo.PTS_Employee where Emp_Username='" + EmployeeName + "' and Emp_Password='" + Password + "'";
            SqlCommand mycomm2 = new SqlCommand(cmd1, con2);
            con2.Open();
            Object Blocked = mycomm2.ExecuteScalar();
            con2.Close();
            //Checks Wether the user is blocked or not
            if (Blocked != null)
            {
                //if the use is not blocke it redirects to the specified page
                if (Blocked.ToString() == "")
                {
                    Session["EmployeeName"] =EmployeeName;
                    Response.Redirect("~/Transactions.aspx");
                }
                else
                {
                    lblError.Text = "You are Temporarily Blocked for Exceeding Max Number of Login Attempts";
                }
            }
                //Checks the attempts of the user if the user attempts are more than 3 it blocks him for login again
            else
            {
                object FailedLoginCounter = this.Page.Cache["UserKey_" + this.txtEmpName.Text];
                if (FailedLoginCounter == null)
                {
                    FailedLoginCounter = 0;
                }
                this.Page.Cache["UserKey_" + this.txtEmpName.Text] = (int)FailedLoginCounter + 1;
                if (((int)this.Page.Cache["UserKey_" + this.txtEmpName.Text]) == 3)
                {
                    SqlConnection con1 = new SqlConnection(connstring);
                    SqlCommand mycomm1 = new SqlCommand("SP_IsBlocked", con1);
                    mycomm1.CommandType = CommandType.StoredProcedure;
                    con1.Open();
                    mycomm1.Parameters.Add("@IsBlocked", SqlDbType.VarChar).Value = "Yes";
                    mycomm1.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = txtEmpName.Text;
                    mycomm1.ExecuteNonQuery();
                    con1.Close();
                    lblError.Text = "You Exceeded The Maximum Login Attempts of 3,You are Blocked for now....Please Contact your Admin for Reuse Of Your Account";
                }
            }
        }
