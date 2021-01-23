    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
    			string xml = @"
    <body>
        <par id = ""1"">
          <prop type=""Content"">One</prop>
          <child xml:id=""1"">
            <span>This is span 1</span>
          </child>
          <child xml:id=""2"">
            <span>This is span 2</span>
          </child>
        </par>
    </body>";
    			XDocument doc = XDocument.Parse(xml);
    			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(doc.CreateNavigator().NameTable);
    			namespaceManager.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
    			XElement span1 = doc.Root.XPathSelectElement(@"/body/par/child[@xml:id = ""1""]/span[1]", namespaceManager);
    			XElement span2 = doc.Root.XPathSelectElement(@"/body/par/child[@xml:id = ""2""]/span[1]", namespaceManager);
    
    			span1.ReplaceWith(span2);
    			span2.ReplaceWith(span1);
    
    			Console.WriteLine(doc);
            }
        }
    }
