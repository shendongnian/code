        /// <summary>
        /// Managing errors from a single location 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Error(object sender, EventArgs e)
        {
            // 1. Get the last error raised
            var error = Server.GetLastError();
            //2. Get the error code to respond with
            var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;
            //3.. Log the error ( I am ignoring 404 error)
            if (code != 404)
            {
                // Write error details to eventlog
                WriteToEventLog(error);
            }
            //4. Clear the response stream
            Response.Clear();
            //5. Clear the server error
            Server.ClearError();
            //6. Render the Error handling controller without a redirect
            string path = Request.Path;
            Context.RewritePath(string.Format("~/Home/Error",code),false);
            IHttpHandler httpHandler = new MvcHttpHandler();
            httpHandler.ProcessRequest(Context);
            Context.RewritePath(path,false);
        }
         /// <summary>
        /// This method writes the exception to the event log we have specified in the web.config or the app.config
        /// </summary>
        /// <param name="exception"></param>
        public void WriteToEventLog(Exception exception)
        {
            EventLog.WriteEntry("abc", exception.Message, EventLogEntryType.Error);
        }
