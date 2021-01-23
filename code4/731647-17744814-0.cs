    public class JSONObjectWrapper
    {
        public string ObjectType;
        public string ObjectInJSON;
        [DoNotSerialize] // sorry do not remember the attribute to exclude it from serialization
        public object ObjectData;
    }
