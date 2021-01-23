      using System.Xml;
    // Name space & class declarations...
    static void ReadXml(string filePath)
            {
                //These would be kept in a settings file but constants for this example
                const string CONNECTION_LISTING_NODE_NAME = "List-of-Connection-Records";
                const string CONNECTION_NODE_NAME = "Connection";
                const string CALL_RATE_ATTRIBUTE_NAME = "Call-Rate";
    
                //Load xml
                var doc = new XmlDocument();
                doc.Load(filePath);
                var root = doc.FirstChild;
                var connectionRecordLists = doc.SelectNodes(String.Format("//{0}",CONNECTION_LISTING_NODE_NAME));
                if (connectionRecordLists == null) return;
                for (var i = 0; i < connectionRecordLists.Count; i++)
                {
                    var connections = connectionRecordLists[i].SelectNodes(CONNECTION_NODE_NAME);
                    if (connections == null) continue;
                    for (var j = 0; j < connections.Count; j++)
                    {
                        if (connections[j].Attributes != null
                            && connections[j].Attributes[CALL_RATE_ATTRIBUTE_NAME] != null)
                        {
                            Console.WriteLine(connections[j].Attributes[CALL_RATE_ATTRIBUTE_NAME].Value);
                        }
    
                    }
                }
            }
