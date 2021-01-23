        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string errorMessage = "Application Exception: " + ex.Message;
            if (ex.InnerException != null)
            {
                errorMessage += Environment.NewLine + "Inner Exception: " + ex.InnerException.Message;
            }
            if (Context != null && Context.Request != null)
            {
                errorMessage += Environment.NewLine + "Absolute Url: " + Context.Request.Url.AbsolutePath;
            }
            Services.LoggerManager.Log(
               Services.LoggerManager.eLogContext.Application,
               Services.LoggerManager.eLogType.Error,
               Context, errorMessage);
        }
