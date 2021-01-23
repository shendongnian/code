    static void Main(string[] args)
    {
        var xml = @"<Master>
                        <Dealers>
                            <Dealer id=""101"">
                            <Description>Auto</Description>
                            <Name>Bon Bon Motors</Name>
                            <Address>
                                <Street>123 W Place St</Street>
                                <City>Chicago</City>
                                <State>IL</State>
                                <Zip>82453</Zip>
                            </Address>
                            <PhoneNo>5451252222</PhoneNo>
                            </Dealer> 
                            <Dealer id=""102"">
                            <Description>Auto</Description>
                            <Name>Bon Bon Motors</Name>
                            <Address>
                                <Street>123 W Place St</Street>
                                <City>Chicago</City>
                                <State>IL</State>
                                <Zip>82453</Zip>
                            </Address>
                            <PhoneNo>5451252222</PhoneNo>
                            </Dealer>
                        <Dealer id=""103"">
                            <Description>Auto</Description>
                            <Name>Bon Bon Motors</Name>
                            <Address>
                                <Street>123 W Place St</Street>
                                <City>Chicago</City>
                                <State>IL</State>
                                <Zip>82453</Zip>
                            </Address>
                            <PhoneNo>5451252222</PhoneNo>
                            </Dealer> 
                        </Dealers>
                        </Master>";
        var results = XDocument.Parse(xml).Root // Master
                               .Descendants("Dealer")
                               .Select(dealer => new
                                   {
                                       Id = dealer.Attribute("id").Value,
                                       Description = dealer.Element("Description").Value,
                                       Name = dealer.Element("Name").Value,
                                       Street = String.Join(", ", dealer.Element("Address")
                                                                       .Elements() // Street, City, State, Zip
                                                                       .Select(element => element.Value)
                                                                       .ToArray())
                                   }).ToList();
        results.ForEach(result => Console.WriteLine("Id: {0}; Description: {1}; Name: {2}; Address: {3}", 
                                                result.Id, result.Description, result.Name, result.Street));
        Console.Read();
    }
