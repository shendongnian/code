        if (!Page.IsPostBack)
        {
            if (Request.QueryString["AcceptsCookies"] != null)
            {
                if (Request.QueryString["AcceptsCookies"].ToString() == "0")
                {
                    LoginBox.InstructionText = Resources.Resource.Login10;
                }
            }
            else
            {
                Response.Cookies["TestCookie"].Value = "ok";
                Response.Cookies["TestCookie"].Expires = DateTime.Now.AddMinutes(1);
                
                string url = Request.Url.ToString();
                url = url.Replace("ReturnUrl", "AcceptsCookies=&ReturnUrl");
            
                Response.Redirect(BasePage.ResolveUrl("~/Common/TestForCookies.aspx?redirect=" + Server.UrlEncode(url)));
            }
        }
