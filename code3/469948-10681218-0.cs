    using System.Xml.XPath;
    
    string xml = @"
        <Peoples>
            <People>
            <Name>RadheyJang</Name> 
            <Location>India</Location> 
            <Work>Software Developer</Work> 
            <Point>5</Point> 
            <details>
                <People>
                <Name>ArunaTiwari</Name> 
                <Location>India</Location> 
                <Work>SoFtwareCoder</Work> 
                <Point>3</Point> 
                <details/>
                <Test>A</Test>
                </People>
            </details>
            <Test>NA</Test>    
            </People>
        </Peoples>";
    XDocument xmlDoc = XDocument.Parse(xml);
            
    var vrresult = from a in xmlDoc.XPathSelectElements("/Peoples/People")
                    select new
                    {
                        Name = a.Element("Name").Value,
                        Location = a.Element("Location").Value,
                        Point = a.Element("Point").Value
                    };
