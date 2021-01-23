          static public string AssemblyDirectory
           {
               get
               {
                   string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                   UriBuilder uri = new UriBuilder(codeBase);
                   string path = Uri.UnescapeDataString(uri.Path);
                   return Path.GetDirectoryName(path);
               }
           }
           public static decimal GetTaxAmount(decimal amount, int year)
            {
                var name = from nm in XElement.Load(AssemblyDirectory +         @"\Taxes.xml").Elements("Year").Elements("Scale")
                           where nm.Parent.Attribute("id").Value == year.ToString()
                           && (decimal)nm.Element("MoreThan") <= amount
                           && (decimal)nm.Element("NotMoreThan") >= amount
                           select new 
                           {
                                TaxAmount =  nm.Element("TaxAmount"),
                                Percentage = nm.Element("Percentage"),
                                MoreThan = nm.Element("MoreThan")
                           };
