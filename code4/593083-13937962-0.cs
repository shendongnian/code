    public ActionResult L2CSV()
    {
        var posts = _dataItemService.SelectStuff();
        string csv = CSV.IEnumerableToCSV(posts);
        // These first two lines simply get our required data as a long csv string
        var fileData = Zip.CreateZip("LogPosts.csv", System.Text.Encoding.UTF8.GetBytes(csv));
        var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = "LogPosts.zip",
            // always prompt the user for downloading, set to true if you want 
            // the browser to try to show the file inline
            Inline = false,
        };
        Response.AppendHeader("Content-Disposition", cd.ToString());
        return File(fileData, "application/octet-stream");
    }
