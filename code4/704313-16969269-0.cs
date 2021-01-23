    if (lines.Length == 1)
                {
                    xml = new XElement(rootElementName,
                    lines.Select(line => new XElement(itemElementName,
                            line.Split(',').Select((column, index) => new XElement(headers[index], "")))));
                }
                else
                {
                    xml = new XElement(rootElementName,
                        lines.Where((line, index) => index > 0)
                            .Select(line => new XElement(itemElementName,
                                line.Split(',').Select((column, index) => new XElement(headers[index], column)))));
                }
