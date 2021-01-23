            using (var clientContext = new ClientContext(@"http://server"))
            {
                var web = clientContext.Web;
                var lst = web.Lists.GetByTitle("Discus");
                var item = lst.GetItemById(2);
                item["Author"] = 3;
                item["Editor"] = 2;
                item.Update();
                clientContext.ExecuteQuery();                        
                Console.WriteLine("done");
            }
