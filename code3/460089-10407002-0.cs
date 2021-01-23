        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            Response.Write("test");
            Response.End(); 
        }
