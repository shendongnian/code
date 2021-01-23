        // file here is the path to your edmx file
        if (!string.IsNullOrEmpty(file))
        {
            var ns = XNamespace.Get("http://schemas.microsoft.com/ado/2008/09/edm");
            var doc = XDocument.Load(file);
            var list = (from xElem in doc.Descendants(ns + "NavigationProperty")
                        where xElem.Attribute("Name").Value.StartsWith("REPORTs"))
                        select xElem).ToList();
            foreach (var item in list)
            {
                var newName = item.Attribute("Relationship").Value.Split('_').LastOrDefault();
                if (!newName.Contains("."))
                    item.SetAttributeValue("Name", newName);
                else
                {
                    var ss = newName.Split('.').LastOrDefault();
                }
            }
            doc.Save(file);
            MessageBox.Show(list.Count.ToString());
        }
