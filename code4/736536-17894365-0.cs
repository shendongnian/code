     DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(entry);
                foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
                {
                    try
                    {
                        foreach (string property in resEnt.Properties.PropertyNames)
                        {
                            string value = resEnt.Properties[property][0].ToString();
                            Console.WriteLine(property + ":" + value);
                        }
                    }
                    catch (Exception)
                    { }
                }
