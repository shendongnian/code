         //Read xml file
         string xmlText = "<text>blah blah &lt;strong&gt; hello &lt;/strong&gt; more text &lt;strong&gt;hello again&lt;/strong&gt; blah blah</text>";
         System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
         doc.LoadXml(HttpUtility.HtmlDecode(xmlText));
         XmlNodeList Nodes =  doc.GetElementsByTagName("strong");
         
         List<string> nodeValues= new List<string>();
         foreach (XmlNode Node in Nodes)
         {
             nodeValues.Add(Node.InnerText);
         }               
