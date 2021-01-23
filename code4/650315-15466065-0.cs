    var data =
        XDocument.Parse(xml)
        .Root
        .Element("response")
        .Element("data")
        .Elements("row")
        .Select(row =>
            new
            {
                Id = Int32.Parse(row.Element("id").Value),
                Parameters = new
                {
                    IpAddress = row.Element("parameters").Element("ipaddress").Value,
                    port = Int32.Parse(row.Element("parameters").Element("port").Value),
                },
                Status = new
                {
                    MemFree = Int32.Parse(row.Element("status").Element("memfree").Value),
                },
            });
