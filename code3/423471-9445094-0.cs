        FileInfo fi = new FileInfo(@"c:\picture.bmp");
        Response.Clear();
        Response.ContentType = "application/x-unknown";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", System.Web.HttpUtility.UrlPathEncode(fi.Name)));
        Response.AddHeader("Content-Length", fi.Length.ToString());
        Response.TransmitFile(fi.FullName);
        Response.End();
