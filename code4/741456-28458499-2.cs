    protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();  
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx")); 
        }
