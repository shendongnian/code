    public class StackOverflow_11234676
    {
        const string XML = @"<SetProfile>
                              <sessionId>A81D83BC-09A0-4E32-B440-0000033D7AAD</sessionId>
                              <profileDataXml>
                                <ArrayOfProfileItem>
                                  <ProfileItem>
                                    <Name>Pulse</Name>
                                    <Value>80</Value>
                                  </ProfileItem>
                                  <ProfileItem>
                                    <Name>BloodPresure</Name>
                                    <Value>120</Value>
                                  </ProfileItem>
                                </ArrayOfProfileItem>
                              </profileDataXml>
                            </SetProfile>";
        public class SetProfile
        {
            public Guid sessionId;
            public XElement profileDataXml;
        }
        public static void Test()
        {
            string inputXML = XML;
            XmlSerializer xs = new XmlSerializer(typeof(SetProfile));
            using (TextReader reader = new StringReader(inputXML))
            {
                SetProfile obj = (SetProfile)xs.Deserialize(reader);
                Console.WriteLine(obj.profileDataXml);
            }
        }
    }
