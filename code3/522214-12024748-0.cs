    //Build the request
    Uri site = new Uri("http://www.google.com");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site);
    CookieContainer cookies = new CookieContainer();
    request.CookieContainer = cookies;
    //Print out the number of cookies before the response (of course it will be blank)
    Console.WriteLine(cookies.GetCookieHeader(site));
    //Get the response and print out the cookies again
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        Console.WriteLine(cookies.GetCookieHeader(site));
    }
    Console.ReadKey();
