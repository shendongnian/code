    var wi = (System.Security.Principal.WindowsIdentity)HttpContext.Current.User.Identity;
    
    var wic = wi.Impersonate();
    try
    {
        var data = JsonConvert.SerializeObject(new
        {
            Property1 = 1,
            Property2 = "blah"
        });
    
        using (var client = new WebClient { UseDefaultCredentials = true })
        {
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            client.UploadData("http://url/api/controller", "POST", Encoding.UTF8.GetBytes(data));
        }
    }
    catch (Exception exc)
    {
        // handle exception
    }
    finally
    {
        wic.Undo();
    }
