    public class Class1 : ISerializable
    { 
        // ....
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var excludeList = (List<String>)context.Context;
    
            if(!excludeList.Contains("Property1"))
            {
                info.AddValue("Property1",Property1);
            }
        }
    }
