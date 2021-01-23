    [Serializable]
            public struct GraphicsPathWrap : ISerializable
            {
                private static string myValue = "This is the value of the class";
    
                public GraphicsPathWrap(SerializationInfo info, StreamingContext ctxt)  // Deserialization Constructor
                {
                    myValue = (string)info.GetValue("MyValue", typeof(string));
                }
    
                // Creates a property to retrieve or set the value. 
                public string MyObjectValue
                {
                    get
                    {
                        return myValue;
                    }
                    set
                    {
                        myValue = value;
                    }
                }
    
                #region ISerializable Members
    
                public void GetObjectData(SerializationInfo info, StreamingContext context)
                {
                    info.AddValue("MyValue", myValue); // Serialize the value
                }
    
                #endregion
            }
