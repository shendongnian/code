        protected void Page_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(YourUploadMethod);
            Response.Redirect("http://google.com");
        }
        public void YourUploadMethod(object state)
        {
            Thread.Sleep(7000);
        }// breakpoint: I was redirected to google and then debugger stopped me here
