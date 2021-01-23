     // returns just the names
      public static IEnumerable<String> GetEmbeddedResourceNames()
            {
                var returnList = new List<String>();
                foreach (var res in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    var s = Assembly.GetExecutingAssembly().GetName();
                    returnList.Add(Regex.Replace(res.Replace(s.Name + ".", ""), @"\.[^.]*$", ""));
                }
                return returnList;
            }
