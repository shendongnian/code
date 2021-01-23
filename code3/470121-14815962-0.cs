    ClientContext clientContext = new ClientContext(_URL);
                List list = clientContext.Web.Lists.GetByTitle("Tasks");
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ViewXml = "<View/>"; //filter
                ListItemCollection listItems = list.GetItems(camlQuery);
                clientContext.Load(list); clientContext.Load(listItems);
                clientContext.ExecuteQuery();
                        try
                        {
                        foreach (ListItem _item in listItems)
                        {
                           //your code 
                        }
