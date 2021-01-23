    List<Root2> list = new List<Root2>();
    Root2 obj = new Root2();
    obj.CUST_HOLD = new CUST_HOLD[] { new CUST_HOLD() { i = 1 }, new CUST_HOLD() { i = 1 }, new CUST_HOLD() { i = 1 } };
    obj.HOLD = new HOLD[] { new HOLD() { i = 1 }, new HOLD() { i = 1 }, new HOLD() { i = 1 } };
      list.Add(obj);
     //Serialize List<Root2>
     System.Xml.Serialization.XmlSerializer Serializer = new     System.Xml.Serialization.XmlSerializer(typeof(List<Root2>),new System.Xml.Serialization.XmlRootAttribute("Root2"));
            
     System.IO.MemoryStream mo = new System.IO.MemoryStream();
     Serializer.Serialize(mo, list);
     string str = UnicodeEncoding.UTF8.GetString(mo.ToArray());
