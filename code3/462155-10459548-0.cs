    protected void CreateUser_Button_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus result;
            try
            {
                if (Page.IsValid)
                {
                    Membership.CreateUser(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, true, out result);
                    
                    switch (result)
                    {
                        case MembershipCreateStatus.DuplicateEmail:
                            Response.Write("Email ID is already exist");
                            break;
                        case MembershipCreateStatus.DuplicateProviderUserKey:
                            break;
                        case MembershipCreateStatus.DuplicateUserName:
                            Response.Write("UserName is already Exists !");
                            break;
                        case MembershipCreateStatus.InvalidAnswer:
                            break;
                        case MembershipCreateStatus.InvalidEmail:
                            Response.Write("Not a Valid Email ID");
                            break;
                        case MembershipCreateStatus.InvalidPassword:
                            Response.Write("Atleast 6 Charcters are required for Password");
                            break;
                        case MembershipCreateStatus.InvalidProviderUserKey:
                            break;
                        case MembershipCreateStatus.InvalidQuestion:
                            break;
                        case MembershipCreateStatus.InvalidUserName:
                            break;
                        case MembershipCreateStatus.ProviderError:
                            Response.Write("Fail to Register ");
                            break;
                        case MembershipCreateStatus.Success:
                            Response.Write("Successfulley Registered");
                            break;
                        case MembershipCreateStatus.UserRejected:
                            Response.Write("Fail to Register, ");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
        }
