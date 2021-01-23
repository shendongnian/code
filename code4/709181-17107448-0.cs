            Dictionary<int, string> fooDictionary = new Dictionary<int, string>();
            fooDictionary.Add(1, "foo");
            fooDictionary.Add(2, "bar");
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("countrylist")
            );
            var countryList = doc.Descendants("countrylist").Single(); // Get Country List Element
            foreach (var bar in fooDictionary) {
                // Add values per item
                countryList.Add(new XElement("country",
                                    new XAttribute("id", bar.Key),
                                    new XAttribute("name", bar.Value)));
            }
