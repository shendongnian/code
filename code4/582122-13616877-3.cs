    XDocument xdoc = XDocument.Load(path_to_xml_file);
    var week = new
    {
        Days = xdoc.Descendants("day")
                    .Select(day => new {
                        Name = ((XText)day.FirstNode).Value.Trim(),
                        Hours = day.Descendants("hour")
                                    .Select(hour => new {
                                        Time = ((XText)hour.FirstNode).Value.Trim(),
                                        Values = hour.Elements()
                                                    .Select(node => (int)node)
                                                    .ToList()
                                    }).ToList()
                    }).ToList()
    };
