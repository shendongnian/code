    namespace FurnatureSaver
    {
        [Serializable()]    
        class ItemData : ISerializable
        {
            public String Color
            {
                get;
                set;
            }
    
            public ItemData()
            {
            }
            public ItemData(SerializationInfo Information, StreamingContext X101)
            {
                Color = (String)Information.GetValue("Color", typeof(string));
    
            }
            public void GetObjectData(SerializationInfo Information, StreamingContext X101)
            {
                Information.AddValue("Color", Color);
    
            }
    
            // I don't see the point of this method. 
            public void Set()
            {
                Color = Color;
            }
        }
    }
