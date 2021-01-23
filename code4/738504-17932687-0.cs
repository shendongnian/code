    public static int BaudRatebx;
    
    private void Form1_Load(object sender, EventArgs e)
    {
                //Declaring the XmlReader.
                XmlTextReader Reader = new XmlTextReader(@"C:\ForteSenderv2.0\Properties.xml");
    
                while (Reader.Read())
                {
                    switch (Reader.NodeType)
                    {
                        //Seeing if the node is and element.
                        case XmlNodeType.Text:
                        case XmlNodeType.Element:
                            if (Reader.Name == "BaudRate")
                            {
                                //Reading the node.
                                Reader.Read();
                                //Making the Baud Rate equal to the .xml file.
                                BaudRatebx = Reader.Value;
                            }
                     }
                 }
     }
