    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
    {
        //These headers are handling the "pre-flight" OPTIONS call sent by the browser
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        HttpContext.Current.Response.End();
    }
