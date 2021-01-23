    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.AddHeader(...))
    HttpContext.Current.Response.ContentType = "audio/x-wav";
    ...
    while ((line = reader.ReadLine()) != null)
    {
        ...
        HttpContext.Current.Response.BinaryWrite(pcmData);
        HttpContext.Current.Response.Flush();
    }
    HttpContext.Current.Response.End();            
