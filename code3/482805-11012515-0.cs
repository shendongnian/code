     using System.Linq;
     using System.Xml.Linq;
     using System.Xml.XPath;
     var element = XElement.Parse(@"<?xml version=""1.0"" encoding=""utf-8""?>
                                <super>
                                  <A value=""1234"">
                                    <a1 xx=""000"" yy=""dddddd"" />
                                    <a1 xx=""111"" yy=""eeeeee"" />
                                    <a1 xx=""222"" yy=""ffffff""/>
                                  </A>
                                </super>");
      // select all the a1's that have xx = 222
      var a1Elements = element.XPathSelectElement("A/a1[@xx='222']"); 
      
      if (a1Elements != null)
         a1Elements.Remove();
      Console.WriteLine(element);
