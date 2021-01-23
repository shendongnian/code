     string xml = @" <entry>
                                <AUTHOR>C. Qiao</AUTHOR> 
                                and 
                                <AUTHOR>R.Melhem</AUTHOR>, 
                                ""<TITLE>Reducing Communication </TITLE>""
                               ,<DATE>1995</DATE>. 
                               </entry>";
                //Parse xml to XDocument
                XDocument doc = XDocument.Parse(xml);
                
                // Get first element (we only have one)
                XElement element = doc.Descendants().FirstOrDefault();
    
                //Create a copy of an element for use by child elements.
                XElement copyElement = new XElement(element);
                //Remove all child nodes from root leaving only text
                element.Elements().Remove();
    
                //Splitting based on the tokens specified
                    var values = Regex.Split(element.Value, @"(\.| |\,|\"")");
                        foreach (string value in values.Where(x => !String.IsNullOrWhiteSpace(x)))
                        {
                            Console.WriteLine(value);
                        }
                //Getting children nodes and splitting the same way
                foreach (XElement elem in copyElement.Elements())
                {
                    var val = Regex.Split(elem.Value, @"(\.| |\,|\"")");
                    foreach (string value in val.Where(x => !String.IsNullOrWhiteSpace(x)))
                    {
                        Console.WriteLine(value + " " + elem.Name);
                    }
                }
                //You can try to play with DescendantsAndSelf 
                //to see if you can do it in single action and with order preserved.
                //foreach (XElement elem in element.DescendantsAndSelf())
                //{
                //    //....
                //}   
