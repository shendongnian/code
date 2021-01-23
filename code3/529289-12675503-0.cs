    var wi = (WindowsIdentity)HttpContext.User.Identity;
    
    var wic = wi.Impersonate();
    try
    {
    
        using (var writer = new StringWriter())
        {
            var json = new JsonSerializer();
            json.Serialize(writer, new
            {
                Property1 = 1,
                Property2 = "blah"
            });
    
            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                client.UploadData("http://url/api/controller", "POST", Encoding.UTF8.GetBytes(writer.ToString()));
            }
        }
    }
    catch (Exception exc)
    {
        return Content(exc.Message);
    }
    finally { 
        wic.Undo();
    }
