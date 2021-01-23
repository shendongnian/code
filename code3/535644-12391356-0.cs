     XPathDocument xpd = new XPathDocument(new StringReader(s));
     XPathNavigator xpn = xpd.CreateNavigator();
     List<IDictionary<string, string>> xmlnsList = new List<IDictionary<string,string>>();
     while (xpn.MoveToFollowing(XPathNodeType.Element))
     {
         xmlnsList.Add(xpn.GetNamespacesInScope(XmlNamespaceScope.All));
     }
     var result = xmlnsList.SelectMany(dict => dict)
                  .ToLookup(pair => pair.Key, pair => pair.Value)
                  .ToDictionary(group => group.Key, group => group.First());
     if (result != null)
     {
         foreach (var prefix in result.Keys)
         {
             xnm.AddNamespace(prefix, result[prefix]);
         }
     }
