     Configuration obj = new Configuration
                            {
                                Configs = new tester
                                              {
                                                  test = new string[]
                                                             {
                                                                 "gabc", "def"
                                                             }
                                              }
                            };
    XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
    string output;
    using (StringWriter writer = new StringWriter())
    {
        serializer.Serialize(writer, obj);
        output = writer.ToString();
    }
