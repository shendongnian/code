        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                Server.ClearError();
                Response.Clear();
                Response.StatusCode = 200;
                // add content below
                Response.Write("");
                Response.End();
            }
        }
