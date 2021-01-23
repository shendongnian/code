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
-------------------------------------------------------------------------------------------
          Books b = new Books();
          DataContractSerializer dcs = new DataContractSerializer(typeof(Books));
              try {
                Stream fs = new FileStream(@"C:\Users\temelm\Desktop\XmlFile.xml", FileMode.Create, FileAccess.Write);
                XmlDictionaryWriter xdw = XmlDictionaryWriter.CreateTextWriter(fs, Encoding.UTF8);
                xdw.WriteStartDocument();
                dcs.WriteObject(xdw, b);
                fs.Flush();
                fs.Close();
            } catch (Exception e) { s += e.Message + "\n"; }
