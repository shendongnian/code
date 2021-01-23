    [Serializable]
    class MyThirdPartyClass : ThirdPartyClass, ISerializable
    {
        public MyThirdPartyClass()
        {
        }
        protected MyThirdPartyClass(SerializationInfo info, StreamingContext context)
        {
            Property1 = (AnotherClass)info.GetValue("Property1", typeof(AnotherClass));
            Property2 = (AnotherClass)info.GetValue("Property2", typeof(AnotherClass));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Property1", Property1);
            info.AddValue("Property2", Property2);
        }
    }
