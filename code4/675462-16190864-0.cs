            ClientContext clientContext = new ClientContext("http://yoursite.com");
            Site site = clientContext.Site;
            DateTime dt = DateTime.Parse("04/24/2013 5:44PM").ToUniversalTime();
            ClientResult<string> cr = Utility.FormatDateTime(clientContext, clientContext.Web, dt, DateTimeFormat.DateTime);
            clientContext.ExecuteQuery();
            string value = cr.ToString();
            DateTime webdt = DateTime.Parse(cr.Value.ToString());
            Console.WriteLine(webdt.ToString());
            Console.Read();
