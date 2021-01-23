    public static void parse()
        {
            Stack<String> stck = new Stack<string>();
            List<String> nodes = new List<string>();
            Dictionary<String, String> dictionary = new Dictionary<string, string>();
            
            using (XmlReader reader = XmlReader.Create("path:\\xml.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                      
                        stck.Push(reader.Name);
                        
                    }
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        StringBuilder str = new StringBuilder();
                        if (stck.Count > 0)
                            nodes = stck.ToList<String>();
                        //List<String> _nodes ;
                        nodes.Reverse(0,nodes.Count);
                        foreach (String node in nodes)
                            str.Append(node + " --> ");
                        
                        dictionary.Add(str.ToString(), reader.Value);
                        str.Clear();
                    }
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        
                        stck.Pop();
                    }
                }
            }
            foreach (KeyValuePair<String, String> KVPair in dictionary)
                Console.WriteLine(KVPair.Key + " : " + KVPair.Value);
            Console.Read();
        }
