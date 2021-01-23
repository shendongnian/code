    protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        {
                string trimUserName = RegisterUser.UserName.Trim();
                if (RegisterUser.UserName.Length != trimUserName.Length)
                {
                    accountlbl.Text = "The username cannot contain leading or trailing spaces.";
                    accountlbl.Visible = true;
                    //Cancel the created user info
                    e.Cancel = true;
                }
                if (RegisterUser.Password.IndexOf(RegisterUser.UserName, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    accountlbl.Text = "The username may not appear anywhere in the password.";
                    accountlbl.Visible = true;
                    //Cancel the created user info
                    e.Cancel = true;
                }
                String FirstName = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FirstName")).Text;
                String LastName = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("LastName")).Text;
                String Company = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CompanyName")).Text;
                String PartsList = ((DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("companyddl")).SelectedValue;
                String UserName = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName")).Text;
                String Password = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Password")).Text;
                String Email = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Email")).Text;
                String Question = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Question")).Text;
                String Answer = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Answer")).Text;
                // Insert a new record into User_Profile            
                if (((Company == "OurCompany" || Company == "OurCompany, Inc.") && PartsList == ""))
                {
                    if (!User.IsInRole("manager"))
                    {
                    Roles.AddUserToRole(UserName, "manager");
                    Role = "manager";
                    }
                }
                if (PartsList == "SF")
                {
                    if (!User.IsInRole("user_sf"))
                    {
                        Roles.AddUserToRole(UserName, "user_sf");
                        Role = "user_sf";
                    }
                }
                if (PartsList == "TL")
                {
                    if (!User.IsInRole("user_tl"))
                    {
                        Roles.AddUserToRole(UserName, "user_tl");
                        Role = "user_tl";
                    }
                }
                if ((Company != "OurCompany" || Company != "OurCompany, Inc.") && PartsList == "")
                {
                    if (!User.IsInRole("user"))
                    {
                        Roles.AddUserToRole(UserName, "user");
                        Role = "user";
                    }
                }
                
                ////Get your Connection String from the web.config...ApplicationServices is the name I have in my web.config
                string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                string insertSql = "INSERT INTO UserProfile(FirstName, LastName, Company, PartsList, UserName, Password, Email, Question, Answer, Role)" +
                                   "VALUES(@FirstName, @LastName, @Company, @Partslist, @UserName, @Password, @Email, @Question, @Answer, @Role)";
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    myConnection.Open();
                    SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                    myCommand.Parameters.AddWithValue("@FirstName", FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", LastName);
                    myCommand.Parameters.AddWithValue("@Company", Company);
                    myCommand.Parameters.AddWithValue("@PartsList", PartsList);
                    myCommand.Parameters.AddWithValue("@UserName", UserName);
                    myCommand.Parameters.AddWithValue("@Password", Password);
                    myCommand.Parameters.AddWithValue("@Email", Email);
                    myCommand.Parameters.AddWithValue("@Question", Question);
                    myCommand.Parameters.AddWithValue("@Answer", Answer);
                    myCommand.Parameters.AddWithValue("@Role", Role);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();                    
                }
        }
