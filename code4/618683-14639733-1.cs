     protected void Application_Error(object sender, EventArgs e)
            {
                var errMsg = Server.GetLastError().Message;
                if (string.IsNullOrWhiteSpace(errMsg)) return;
                //Make sure parameter names to be passed is are not equal
                Response.RedirectToRoute("ErrorHandler", new { strErrMsg=errMsg });
                this.Context.ClearError();
            }
