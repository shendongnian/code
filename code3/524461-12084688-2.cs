    private void button1_Click(object sender, EventArgs e)
    {
    string xmlToSerializePath = @"c:/temp/stackowrflowquestionxml.xml";
                
    XmlSerializer serializer = new XmlSerializer(typeof(Message));
    StreamWriter writer = new StreamWriter(xmlToSerializePath);
    
    Message messageToSerialize = new Message
                                        {
                                            DateTime = new DateTime(2012, 1, 31, 8, 15, 58),
                                            Form = new User()
                                                      {
                                                            FriendlyName = "Chocolade"
                                                      },
                                            To = new User
                                                      {
                                                            FriendlyName = "adilipman@yahoo.com"
                                                      },
                                            SessionID = 1,
                                            Text = "testing the test."
                                         };
           serializer.Serialize(writer, messageToSerialize);
           writer.Close();
    }
