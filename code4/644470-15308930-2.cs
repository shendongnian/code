          [Serializable]
            public struct GraphicsPathWrap : ISerializable
            {
                private static string myValue = "This is the value of the class";             
    
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
                    
                }
    
                #endregion
            } 
