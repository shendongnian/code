            var xmlDocument = XDocument.Load("C:\\TEMP\\test.xml");
            var nodesList = from xmlNode in xmlDocument.Descendants("Dealer")
                            select
                                new
                                    {
                                        Id = xmlNode.Attribute("id").Value,
                                        Description = xmlNode.Descendants("Description").ElementAt(0).Value,
                                        Name = xmlNode.Descendants("Name").ElementAt(0).Value,
                                        Address = new
                                            {
                                                Street = xmlNode.Descendants("Address").Descendants("Street").ElementAt(0).Value,
                                                City = xmlNode.Descendants("Address").Descendants("City").ElementAt(0).Value,
                                                State = xmlNode.Descendants("Address").Descendants("State").ElementAt(0).Value,
                                                ZipCode = xmlNode.Descendants("Address").Descendants("Zip").ElementAt(0).Value
                                            },
                                        PhoneNumber = xmlNode.Descendants("PhoneNo").ElementAt(0).Value
                                    }           
                ;
            foreach (var node in nodesList)
            {
                Console.WriteLine(node.Id);
            }
            Console.ReadKey();
