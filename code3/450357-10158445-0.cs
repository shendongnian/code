            XmlTextReader reader = new XmlTextReader("http://www.cairo360.com/xml/feeds/rss/Cairo360Events.xml");
            // Skip non-significant whitespace  
            reader.WhitespaceHandling = WhitespaceHandling.Significant;
            // Read nodes one at a time  
            while (reader.Read())
            {
                // Print out info on node  
                Console.WriteLine("{0}: {1}", reader.NodeType.ToString(), reader.Name);
            }  
