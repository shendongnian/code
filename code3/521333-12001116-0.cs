        string q = Request.QueryString["Url"].ToString();
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=\""
            + file + "\"");
        Response.ContentType = "text/plain";
        Response.WriteFile(Server.MapPath(d + q));
        Response.End();
