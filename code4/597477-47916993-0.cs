    void Application_BeginRequest(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "OPTIONS")
        {
            Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            Response.AddHeader("Access-Control-Max-Age", "1728000");
            Response.End();
        }
        else
        {
            Response.AddHeader("Access-Control-Allow-Credentials", "true");
            if (Request.Headers["Origin"] != null)
                Response.AddHeader("Access-Control-Allow-Origin" , Request.Headers["Origin"]);
            else
                Response.AddHeader("Access-Control-Allow-Origin" , "*");
        }
    }
