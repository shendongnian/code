    public void ReadXml(System.Xml.XmlReader reader)
    {
        XmlSerializer serializer = null;
        bool flag;
        bool isEmpty = reader.IsEmptyElement;
        reader.ReadStartElement();
        if (isEmpty)
        {
            return;
        }
        while (true)
        {
           flag = false;
           if (string.Compare(reader.Name, typeof(Foo1).Name) == 0)
           {
              serializer = new XmlSerializer(typeof(Foo1));
              flag = true;
           }
           else if (string.Compare(reader.Name, typeof(Foo2).Name) == 0)
           {
              serializer = new XmlSerializer(typeof(Foo2));
              flag = true;
           }
           if (flag)
              this.Add((IFoo)serializer.Deserialize(reader));
           else
              break;
        }
        reader.ReadEndElement();
    }
