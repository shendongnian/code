        // Code that runs on every request
        if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("http://website.net"))
        {
            HttpContext.Current.Response.Status = "301 Moved Permanently";
            HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("http://website.net", "http://www.website.net"));
        }
    }
