        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(1));
        Response.Expires = 0;
        Response.CacheControl = "no-store";
        Response.Cache.SetNoStore();
        Response.AppendHeader("Pragma", "no-cache");
        Response.post-check=0;
        Response.pre-check=0;
