    using System.Web.Util;
    WebRequest req = WebRequest.Create(ctx.SvcUrl);
    req.Method = "POST";
    req.ContentType = "application/x-www-form-urlencoded";
    using (var writer = new StreamWriter(req.GetRequestStream(), 
        System.Text.Encoding.ASCII))
    {
        var encoder = new HttpEncoder();
        string reqBody = String.Format("first={0}&last={1}",
            encoder.HtmlEncode("<bill/>"), 
            encoder.HtmlEncode("smith") ); 
        writer.Write(reqBody);
    }
    rsp = req.GetResponse();
    var strm = rsp.GetResponseStream();
    var rdr = new StreamReader(strm);
    string input = rdr.ReadToEnd();
