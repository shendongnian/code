         static void Main(string[] args)
            {
                string xml = @"<testxml><Day>
    <Monday>true</Monday>
    <Tuesday>false</Tuesday>
    <Wednesday>true</Wednesday>
    <Thursday>false</Thursday>
    <Friday>true</Friday>
    <Saturday>false</Saturday>
    <Sunday>true</Sunday>
    </Day>
    <Time>
    <dateTime>12:21</dateTime>
    </Time>
    </testxml>";
    
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xml);
                //xDoc.Load(xmlpath);
                
                string xpath = "/testxml/Day/*";
                XmlNodeList xNode = xDoc.SelectNodes(xpath);
    
                foreach (XmlNode node in xNode)
                {
                    string day = node.LocalName;
                    Console.WriteLine(day + ", value=\"" + node.InnerText + "\"");
                }
    
                xpath = "/testxml/Time/dateTime";
                XmlNode node1 = xDoc.SelectSingleNode(xpath);
                Console.WriteLine(node1.LocalName + ", value=\"" + node1.InnerText + "\"");
                Console.ReadLine();
            }
