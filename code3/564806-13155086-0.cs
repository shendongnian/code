    using System.Net;
    using System.IO;
    WebClient client = new WebClient ();
    // Add a user agent header in case the requested URI contains a 
    query.
    client.Headers.Add ("user-agent", "Mozilla/4.0
     (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR
    1.0.3705;)");
    client.QueryString.Add("user", "xxxx");
    client.QueryString.Add("password", "xxxx");
    client.QueryString.Add("api_id", "xxxx");
    client.QueryString.Add("to", "xxxx");
    client.QueryString.Add("text", "This is an example message");
    string baseurl ="http://api.clickatell.com/http/sendmsg";
    Stream data = client.OpenRead(baseurl);
    StreamReader reader = new StreamReader (data);
    string s = reader.ReadToEnd ();
    data.Close ();
    reader.Close ();
    return (s);
