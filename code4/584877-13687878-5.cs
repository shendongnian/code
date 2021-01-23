    Product p = new Product()
    {
        Cycle = new Cycle() { Type = "x0446" },
        Brand = new Brand() { Type = "z773g", Include = "All" },
        Updates = new List<Item>()
        {
            new Item() { Name = "Foo", 
                         Artifacts = new List<Artifact>() {
                            new Artifact() { Action = 3, Kind = 6 }
                        }
            },
            new Item() { Name = "Bar", 
                         Artifacts = new List<Artifact>() {
                            new Artifact() { Action = 3, Kind = 6 },
                            new Artifact() { Action = 3, Kind = 53 },
                        }
            }
        }
    };
    XmlSerializer serializer = new XmlSerializer(typeof(Product));
    Stream stream = new MemoryStream(); // use whatever you need
    serializer.Serialize(stream, p);
