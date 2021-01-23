     public void ProcessRequest (HttpContext context) 
     {
        if (context.Request.QueryString["copyright"] == "y")
        {     
            context.Response.ContentType = "image/jpg";
    	    context.Response.WriteFile("~/Flower1.jpg");
        }
     } 
