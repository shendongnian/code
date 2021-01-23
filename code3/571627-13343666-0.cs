        List<string> values = new List<string>();
        using ( XmlReader reader = XmlReader.Create("your path", settings)) 
        {
            while ( reader.Read() ) 
            {
                if ( reader.NodeType == XmlNodeType.Element ) 
                {
                    if ( reader.HasAttributes ) 
                    {
                        if ( reader.GetAttribute("UnityName") != null ) 
                        {
                            signalsa = reader.GetAttribute("UnityName");
                            if(!values.Contains(signalsa))
                            {
                                values.Add(signalsa);
                                //rest of your code goes here...
                            }
                        }
                    }
                }
            }
        }
         
