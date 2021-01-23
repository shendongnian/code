    Community community = new Community {
        Author = "xxx xxx",
        CommunityId = 0,
        Name = "name of community",
        Addresses = new List<Address> {
            new RegisteredAddress {
                AddressLine1 = "xxx",
                AddressLine2 = "xxx",
                AddressLine3 = "xxx",
                City = "xx",
                Country = "xxxx",
                PostCode = "0000-00"
            },
            new TradingAddress {
                AddressLine1 = "zz",
                AddressLine2 = "xxx"
            }
        }
    };
    
    XmlSerializer serializer = new XmlSerializer(typeof(Community));
    serializer.Serialize(File.Create("file.xml"), community);
