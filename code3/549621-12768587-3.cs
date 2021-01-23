    WebClient client = new WebClient();
    string value;
    
    try
    {
    value = client.DownloadString("http://foo.com");
    }
    catch (WebException ex)
    {
    value = ex.Message;
    }
    Console.WriteLine(value.Length);
    Console.WriteLine(value);
    Console.WriteLine("Press any key to continue");
    Console.ReadKey(true);
