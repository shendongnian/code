        void Application_BeginRequest(object sender, EventArgs e) {
            if (Request == null || Request.Cookies == null) {
                return;
            }
            if (Request.Cookies.Count < 10) {
                return;
            }
            for (int i = 0; i < Request.Cookies.Count; ++i) {
                if (StringComparer.OrdinalIgnoreCase.Equals(Request.Cookies[i].Name, System.Web.Security.FormsAuthentication.FormsCookieName)) {
                    continue;
                }
                if (!Request.Cookies[i].Name.EndsWith("_SKA", System.StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }
                if (i > 10) {
                    break;
                }
                
                System.Web.HttpCookie c = new System.Web.HttpCookie(Request.Cookies[i].Name);
                c.Expires = DateTime.Now.AddDays(-1);
                c.Path = "/";
                c.Secure = false;
                c.HttpOnly = true;
                Response.Cookies.Set(c);
            }
        }
