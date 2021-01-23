    abstract class Foo
    {
        public byte[] SerializeProperties()
        {
             var props = new List<byte>();
             SerializeMyProperties(props);
             return props.ToArray();
        }
    
        private virtual void SerializeMyProperties(List<byte> props)
        {
            byte[] serializedByteArrayForThisInstance;
    
            //Magic!
             props.AddRange(serializedByteArrayForThisInstance);
        }
    }
    
    class Bar : Foo
    {
        private virtual void SerializeMyProperties(List<byte> props)
        {
            //Call the Foo's SerializeMyProperties first so it fills the first part of the list
            base.SerializeMyProperties(props);
    
            byte[] serializedByteArrayForThisInstanceToo;
    
            //Even More Magic!
    
             props.AddRange(serializedByteArrayForThisInstanceToo);
        }
    }
    
    class Baz : Bar
    {
        private virtual void SerializeMyProperties(List<byte> props)
        {
            //Call the Bar's SerializeMyProperties first so it fills the first two parts of the list
            base.SerializeMyProperties(props);
    
            byte[] iAmRunningOutOfVariableNames;
    
            //Here Be Dragons!
    
             props.AddRange(iAmRunningOutOfVariableNames);
        }
    }
