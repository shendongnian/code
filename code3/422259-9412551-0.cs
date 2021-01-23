    WebClient client = new WebClient();
    string url = @"http://www.agiledeveloper.com/articles/BackgroundWorker.pdf";
    byte[] data = client.DownloadData(new Uri(url));
    
    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}", "aspnet.pdf"));
    Response.OutputStream.Write(data, 0, data.Length);
