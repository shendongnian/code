     var productTypes = from productType in xml.Elements("ProductType")
                    select new {
                       Name = productType.Attribute("Name").Value,
                       Amount = Convert.ToInt32(productType.Element("Amount").Value),
                       // How to get all Pattern elements from that ProductType?
                       Patterns = from patt in productType.Elements("Pattern")
                                  select new { Length = int.Parse(patt.Attribute("Length").Value),
                                               .... }
                     };
