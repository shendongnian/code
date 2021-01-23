            List<BaseContact> items = new List<BaseContact>();
            for (int i = 0; i < 5; i++)
            {
                BaseContact item;
                if (i % 2 == 0) item = new FbContact(); else item = new LinkedInContact();
                item.Url = "My name " + i;
                items.Add(item);
            }
            foreach (var contact in items)
            {
                HyperLink link = new HyperLink();
                NavigationCreator.SetUrl(contact, link);
                Console.WriteLine(link.NavigateUrl);
            }
            Console.Read();
