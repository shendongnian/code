    void Application_Error(object sender, EventArgs e)
            {
                Exception ex = Server.GetLastError();
                if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
                {
                    Response.Redirect("~/Error/404");
                }
                else
                {
                    Response.Redirect("~/Error/Other");
                }
                Server.ClearError();
            }
