        string siteUrl = "http://MyServer/sites/MySiteCollection";
        ClientContext clientContext = new ClientContext(siteUrl);
        Web oWebsite = clientContext.Web;
        ListCollection collList = oWebsite.Lists;
        clientContext.Load(collList);
        clientContext.ExecuteQuery();
        foreach (SP.List oList in collList)
        {
            Console.WriteLine("Title: {0} Created: {1}", oList.Title, oList.Created.ToString());
        }
