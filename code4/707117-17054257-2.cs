    public class DateJsonConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new Type[] { typeof(DateTime) }; }
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {            
            return new Dictionary<string, object>()
            {
                { "Value", ((DateTime)obj).ToString("g") }
            };
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
