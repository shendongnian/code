    MyClass temp = null;
    using(MemoryStream theObjectToBeDeserialized = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MyClass));
        temp = (MyClass)serializer.ReadObject(theObjectToBeDeserialized);
    }
