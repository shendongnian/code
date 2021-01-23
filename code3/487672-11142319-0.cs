    MyClass1 obj = new MyClass1();
    DataContractSerializer dcs = new DataContractSerializer(typeof(MyClass1));
    using (Stream stream = new FileStream(@"C:\tmp\file.xml",
         FileMode.Create, FileAccess.Write))
                        {
                            using (XmlDictionaryWriter writer = 
        XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
                            {
                                writer.WriteStartDocument();
                                dcs.WriteObject(writer, obj);
                            }
                        }
