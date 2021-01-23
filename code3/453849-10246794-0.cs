    protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session.Count == 0 || Session["Username"] == null)
                Response.Redirect("~/Login.aspx", true);
            CheckRole();
        }
        public void CheckRole()
        {
            if (System.Web.HttpContext.Current.Session.Count > 0)
            {
                tab= common.GetUserDetails(Session["Username"]);
                if (tab.Rows.Count == 1)
        	 {
                     firstName = tab.Rows[0][2].ToString();
                     userPassword = tab.Rows[0][4].ToString();
                     RoleID = tab.Rows[0][5].ToString();
        	}
       
               if (RoleID != "1")
                {
                     Menu CAMenu = new Menu();
                     int count = CAMenu.Items.Count;
                     for (int i = 3; i > 0; i--)
                      {
                        string text = CAMenu.Items[i - 1].Text;
                        CAMenu.Items.RemoveAt(i - 1);
                      }
		//your label logic
                lbWelcomeMessage.Text = "Welcome"+" "+ firstName;
                ((SiteMaster)Page.Master).MyText = lbWelcomeMessage.Text;
                Response.Redirect("AdHocSMS.aspx");
            }
            else
            {
		//Logic
                Response.Redirect("NewTemplate.aspx");
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx", true);
        }
    }
