    [Serializable]
    public class SerializableExpandoObject : DynamicObject, ISerializable
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>()
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return properties.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            properties.Add(binder.Name, value);
            return true;
        }
        ....
    }
