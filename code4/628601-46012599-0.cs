    using (var client = new System.Net.WebClient())
    {
        var _imagebytes = client.DownloadData(string.Format(@"~/MemberPages/UpdatePhoto.aspx?SiteKey={0}&TimeStamp={1}", foo.Site_ID, foo.timestamp[n1 - 1]));
        Response.Clear();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", "MyImage.jpg"));
        Response.AddHeader("Content-Length", _imagebytes.Length.ToString("F0"));
        Response.OutputStream.Write(_imagebytes, 0, _imagebytes.Length);
        Response.End();
    }
