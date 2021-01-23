    private static dynamic GetExpandoForNodes(IEnumerable<XElement> nodes)
        {            
            var config = new ExpandoObject() as IDictionary<string, Object>;
            foreach (XElement n in nodes)
            {
                if (n.Descendants().Count() == 0)
                {
                    //create your property name from the xml tags, by converting to title-case and removing the underscore
                    string propName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(n.Name.ToString().ToLower()).Replace("_", "");
                    var nodecount = from c in nodes
                                    where c.Name == n.Name
                                    select c;                    
                    if (nodecount.Count() > 1)
                    {
                        List<string> lst = new List<string>();
                        if ((config as IDictionary<String, object>).ContainsKey(propName))
                        {                            
                            lst = (List<string>)(config as IDictionary<String, object>)[propName];
                            lst.Add(n.Value.Trim());
                            (config as IDictionary<String, object>)[propName] = lst;
                        }
                        else
                        {
                            (config as IDictionary<String, object>)[propName] = new List<string>() { n.Value.Trim() };
                        }
                    }
                    else
                    {
                        (config as IDictionary<String, object>)[propName] = n.Value.Trim();
                    }              
                }
                else
                {
                    dynamic child = GetExpandoForNodes(n.Descendants());                                        
                }
            }
            return config;
        }
