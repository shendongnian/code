            // Iterating over nodes to build the dictionary
            foreach (HtmlNode city in citiesNodes)
            {
                if (city.NextSibling != null)
                {
                    string key   = city.NextSibling.InnerText;
                    string value = city.Attributes["value"].Value;
                    citiesHash.AddCity (key,value);
                }
            }
