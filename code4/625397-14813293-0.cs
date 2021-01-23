       if (!IsPostBack)
       {
         if (Request.Cookies["userinfo"] != null)
            {
                HttpCookie objCookie = Request.Cookies["userinfo"];
                txtUserName.Text = objCookie.Values["username"];
                txtPassword.Attributes.Add("value", objCookie.Values["password"]);
                chkRemember.Checked = true;
            }
       }
       protected void btnlogin_Click1(object sender, EventArgs e)
       {
          if (chkremember.Checked)
           {
              
                if (Request.Cookies["userinfo"] != null)
                {
                    HttpCookie objCookie = Request.Cookies["userinfo"];
                    objCookie.Values.Remove("username");
                    objCookie.Values.Remove("password");
                    objCookie.Values["username"] = txtUserName.Text.Trim();
                    objCookie.Values["password"] = txtPassword.Text.Trim();
                    objCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(objCookie);
                }
                else
                {
                    HttpCookie objCookie = new HttpCookie("userinfo");
                    objCookie.Values["username"] = txtUserName.Text.Trim();
                    objCookie.Values["password"] = txtPassword.Text.Trim();
                    objCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(objCookie);
                }
           }
       }
