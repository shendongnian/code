     int intLoop = 0;
                        XmlNodeList Nodes = xmlDoc.GetElementsByTagName("AMASM");            
                        //  Loop through the list
                        while (Nodes.Count != 0)
                        {
                            foreach (XmlNode Node in Nodes)
                            {
                                if ( ! ( (Node.Attributes["AssetSysID"].Value) == hdnGridAssetSysID.Value) )
                                {
                                    Node.ParentNode.RemoveChild(Node); //   <--This line messes with our iteration and forces us to get a new list after each remove    
                                    //  Stop the loop
                                    break;
                                }                   
                            }
                            //  Get a refreshed list of offending nodes                
                            Nodes = xmlDoc.GetElementsByTagName("AMASM");
                            intLoop++;
                            if (intLoop > 5000) break;   //	<-reason for that code is to break the loop out of infinity
                        }
                        Nodes = null;
                        intLoop = 0;  
