    XmlDocument doc = new XmlDocument();
    doc.LoadXml(@"
    <root name='rootAttribute'>
        <OrderRequest name='one' />
        <OrderRequest name='two' />
        <OrderRequest name='three' />
    </root>
    "); // Load some random xml - use function to load whatever you need
    MemoryStream ms = new MemoryStream();
    using (XmlWriter writer = XmlWriter.Create(ms))
    {
        doc.WriteTo(writer); // Write to memorystream
    }
    byte[] data = ms.ToArray();
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ContentType = "text/xml";
    HttpContext.Current.Response.AddHeader("Content-Disposition:",
                        "attachment;filename=" + HttpUtility.UrlEncode("samplefile.xml")); // Replace with name here
    HttpContext.Current.Response.BinaryWrite(data);
    HttpContext.Current.Response.End();
    ms.Flush(); // Probably not needed
    ms.Close();
