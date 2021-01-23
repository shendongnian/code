    protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Master.FindControl("CAMenu").Visible = false;
                Master.FindControl("loginStatus").Visible = false;
            }
            catch (Exception ex)
            {
                new Logger().Log("ShortCom.Login.btnLogin_Click(object sender, EventArgs e)", ex.Message);
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void LoadMessageBox(string MessageID)
        {
            try
            {
                messages = new GUIMessages();
                popupExtend = new ModalPopupExtender();
                lbMessage = (Label)Master.FindControl("label5");
                lbMessage.Text = messages.GetGUIMessage(GUIModule.Login, MessageID);
                popupExtend = (ModalPopupExtender)Master.FindControl("popupExtender");
                popupExtend.Show();
            }
            catch (Exception ex)
            {
                new Logger().Log("ShortCom.Login.LoadMessageBox(string MessageID)", ex.Message);
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUsername.Text;
                string password = txtPassword.Text;
                if (userName == string.Empty && password == string.Empty)
                {
                    LoadMessageBox("5");
                    txtUsername.Focus();
                    return;
                }
                if (userName == string.Empty)
                {
                    LoadMessageBox("1");
                    txtUsername.Focus();
                    return;
                }
                else if (password == string.Empty)
                {
                    LoadMessageBox("3");
                    txtPassword.Focus();
                    return;
                }
                User user = new User(userName);
                DataTable tab = new DataTable();
                tab = user.GetUserDetails(userName);
                string firstName = string.Empty;
                string userPassword = string.Empty;
                string RoleID = string.Empty;
                string userID = string.Empty;
                Session["UserName"] = userName;
                if (tab.Rows.Count == 0)
                {
                    LoadMessageBox("6");
                    txtPassword.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                    txtUsername.Focus();
                    return;
                }
                if (tab.Rows.Count == 1)
                {
                    userID = tab.Rows[0][0].ToString();
                    firstName = tab.Rows[0][1].ToString();
                    userPassword = tab.Rows[0][2].ToString();
                    RoleID = tab.Rows[0][3].ToString();
                    Session["UserID"] = userID;
                }
                
                    if (userPassword == password)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        LoadMessageBox("4");
                        txtPassword.Focus();
                        return;
                    }
                
            }
            catch (Exception ex)
            {
                new Logger().Log("ShortCom.Login.btnLogin_Click(object sender, EventArgs e)", ex.Message);
                Response.Redirect("~/Error.aspx");
            }
        }
