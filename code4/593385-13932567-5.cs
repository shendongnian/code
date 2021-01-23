    using System.Collections.Specialized;
    using System.Configuration;
    public string GetAddress1()
    {
        NameValueCollection section =
            (NameValueCollection)ConfigurationManager.GetSection("ToAddresses");
        return section["name1"];
    }
