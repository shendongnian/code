    var message=  
                  from item in XElement.Load("message.xml").Descendants("Data") 
                     select new
                     {
                          StatusText= item.Element("StatusText").Value,
                          MessageID= item.Element("MessageID").Value,
                          Recipient= item.Element("Recipient").Value
                      };
