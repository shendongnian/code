    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["newCookie"] == null)
        {
            Response.Cookies["newCookie"].Value = "Hello, world!";
            var myValue = Request.Cookies["newCookie"].Value;
        }
    }
