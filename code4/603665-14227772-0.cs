     XElement root = XElement.Parse(input);
                    XElement dataElement = root.Descendants("DATA").FirstOrDefault();
                    XCData cdata = dataElement == null ? null : dataElement.FirstNode as XCData;
                    if (cdata == null)
                    {
                        return;
                    }
                    
                    XElement nestedXml = XElement.Parse(cdata.Value);
                    XNamespace ns = @"http://www.com";
                    var com = nestedXml.Descendants(ns + "PLACES").First();
        
                    com.Value = "Incomplete App Email sent to member." + com.Value;
        
                    cdata.Value = nestedXml.ToString(SaveOptions.DisableFormatting);
                    string updatedOutput = cdata.ToString();
