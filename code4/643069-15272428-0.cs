    try
    {
        WebRequest request = WebRequest.Create("http://192.1111.1.1111");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        ViewBag.Message = response.ContentLength;
    }
    catch (WebException e)
    {
        ViewBag.Message = "failed";
    }
