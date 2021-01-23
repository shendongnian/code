    protected void ButtonClick(object sender, EventArgs e)
    {
        string name = Request.Form["fname"];
        if(!String.IsNullOrEmpty(name))
        {
            Response.Write(name);
        }
    }
