    XDocument xdoc = XDocument.Load(path_to_xml_file);
    var week = new
    {
        Days = xdoc.Descendants("day")
                    .Select(day => new {
                        Name = (string)day.Attribute("name"),
                        Hours = day.Descendants("hour")
                                    .Select(hour => new {
                                        Time = (string)hour.Attribute("time"),
                                        Values = hour.Elements()
                                                    .Select(node => (int)node)
                                                    .ToList()
                                    }).ToList()
                    }).ToList()
    };
