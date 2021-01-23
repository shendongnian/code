    void Application_Error(object sender, EventArgs e)
    {
        if (Request.TotalBytes > 40960 * 1024)
        {
            Server.ClearError();
            Response.Clear();
            Response.Write("File uploaded is greater than 40 MB");
        }
    }
