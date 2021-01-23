    string xml = @"<ENTRY><AUTHOR>C. Qiao</AUTHOR>
                                  <AUTHOR>R.Melhem</AUTHOR>
                                  <TITLE>Reducing Communication </TITLE>
                                  <DATE>1995</DATE>
                           </ENTRY>";
            XElement doc = XElement.Parse(xml);
            foreach (XElement element in doc.Elements())
            {
                
                var values = element.Value.Split(' ');
                foreach (string value in values)
                {
                    Console.WriteLine(element.Name + " " + value);
                }
            }
