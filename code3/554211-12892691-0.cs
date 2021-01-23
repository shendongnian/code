       string OldXml = @"<Root>
                          <Childs>
                          <first>this is first</first>
                          <second>this is second </second>
                          </Childs>        
                          </Root>";
    
                var NewXml = XElement.Parse(OldXml);
                foreach (var node in NewXml.Descendants())
                {
                    if (node.Name.LocalName == "first")
                    {
                        node.Value = "1";
                    }
                }
                var reader = NewXml.CreateReader();
                reader.MoveToContent();
                string newxml = reader.ReadInnerXml();
