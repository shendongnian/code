    WebRequest request = WebRequest.Create("...."); //Adjust your adress
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    if (response == null || response.StatusCode != HttpStatusCode.OK)
    {
      System.Console.Write("is KO");
    }
    else
    ...
