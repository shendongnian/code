    XDocument xDoc1 = XDocument.Parse(@" <Colleges> <College id=""1"" > <Name>Guru Kashi University</Name> <ShortName>GKU</ShortName> <Address>Talvandi Sabo</Address> <City>Bathinda</City> <Contact>09876543210</Contact> </College>  <College id=""2"" > <Name>Shaheed Udham Singh</Name> <ShortName>SUS</ShortName> <Address>Tangori</Address> <City>Mohali</City> <Contact>01234567890</Contact> </College> </Colleges>");
    
    var result = xDoc1.Root.Elements("College")
                                              .Where(x => x.FirstAttribute.Name == "id" && 
                                                         x.FirstAttribute.Value == "1");
