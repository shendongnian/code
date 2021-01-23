    using System.Collections.Specialized;
    using System.Configuration;
    public string GetTo()
    {
        NameValueCollection section =
            (NameValueCollection)ConfigurationManager.GetSection("MailAddressing");
        return section["To"];
    }
