     void Application_BeginRequest(object sender, EventArgs e)
            {
                //get the passed parameters
                var req = ((HttpApplication)(sender)).Request;
                var name = req.QueryString["name"] ?? string.Empty;
                var role = req.QueryString["role"] ?? string.Empty;
    
                //check the role
                if (!role.Equals("admin"))
                {
                    //return http access denied
                    var res = ((HttpApplication)(sender)).Response;
                    res.StatusCode = 401;
                }
            }
