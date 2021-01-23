        var c = Request.Cookies["FedAuth"];
        c.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(c);
        c = Request.Cookies["FedAuth1"];
        c.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(c);
