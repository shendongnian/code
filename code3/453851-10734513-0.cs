      public void CheckRole()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session.Count > 0)
                {
                    string firstName = string.Empty;
                    // string userPassword = string.Empty;
                    string RoleID = string.Empty;
                    Common common = new Common();
                    DataTable tab = new DataTable();
                    string userName = (string)Session["UserName"];
                    User user = new User(userName);
                    tab = user.GetUserDetails(userName);
                    if (tab.Rows.Count == 1)
                    {
                        firstName = tab.Rows[0][1].ToString();
                        RoleID = tab.Rows[0][3].ToString();
                    }
                    if (RoleID != "1")
                    {
                        int count = CAMenu.Items.Count;
                        if (count == 5)
                        {
                            for (int menuCount = 3; menuCount > 0; menuCount--)
                            {
                                string text = CAMenu.Items[menuCount - 1].Text;
                                CAMenu.Items.RemoveAt(menuCount - 1);
                            }
                        }
                        lbLoginMessage.Text = "Welcome," + " " + firstName;
                        loginStatus.Visible = true;
                    }
                    else
                    {
                        lbLoginMessage.Text = "Welcome," + " " + firstName;
                        loginStatus.Visible = true;
                    }
                }
                else
                {
                    Session.Abandon();
                    Response.Redirect("~/Login.aspx", true);
                }
            }
            catch (Exception ex)
            {
                new Logger().Log("ShortCom.SiteMaster.CheckRole()", ex.Message);
                Response.Redirect("~/Error.aspx");
            }
        }
