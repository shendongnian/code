        public static class JsonSerializerExtensions
        {
            public static string ToJsonString(this object target,bool ignoreNulls = true)
            {
                var javaScriptSerializer = new JavaScriptSerializer();
                if(ignoreNulls)
                {
                    javaScriptSerializer.RegisterConverters(new[] { new PropertyExclusionConverter(target.GetType(), true) });
                }
                return javaScriptSerializer.Serialize(target);
            }
        
            public static string ToJsonString(this object target, Dictionary<Type, List<string>> ignore, bool ignoreNulls = true)
            {
                var javaScriptSerializer = new JavaScriptSerializer();
                foreach (var key in ignore.Keys)
                {
                    javaScriptSerializer.RegisterConverters(new[] { new PropertyExclusionConverter(key, ignore[key], ignoreNulls) });
                }
                return javaScriptSerializer.Serialize(target);
            }
        }
    
    
    public class PropertyExclusionConverter : JavaScriptConverter
        {
            private readonly List<string> propertiesToIgnore;
            private readonly Type type;
            private readonly bool ignoreNulls;
    
            public PropertyExclusionConverter(Type type, List<string> propertiesToIgnore, bool ignoreNulls)
            {
                this.ignoreNulls = ignoreNulls;
                this.type = type;
                this.propertiesToIgnore = propertiesToIgnore ?? new List<string>();
            }
    
            public PropertyExclusionConverter(Type type, bool ignoreNulls)
                : this(type, null, ignoreNulls){}
    
            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { this.type })); }
            }
    
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                var result = new Dictionary<string, object>();
                if (obj == null)
                {
                    return result;
                }
                var properties = obj.GetType().GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (!this.propertiesToIgnore.Contains(propertyInfo.Name))
                    {
                        if(this.ignoreNulls && propertyInfo.GetValue(obj, null) == null)
                        {
                             continue;
                        }
                        result.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));
                    }
                }
                return result;
            }
    
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException(); //Converter is currently only used for ignoring properties on serialization
            }
        }
