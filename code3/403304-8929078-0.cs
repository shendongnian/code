    Lists.Lists proxy = new Lists.Lists();
    proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
    XmlNode listCollection = proxy.GetListCollection();
    foreach (XmlNode node in listCollection.ChildNodes)
    {
        bool hidden = bool.Parse(node.Attributes["Hidden"].Value);
        if (!hidden)
        {
           Console.WriteLine(node.Attributes["Title"].Value);
        }
    }
