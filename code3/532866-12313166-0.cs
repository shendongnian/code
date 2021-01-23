    public class SerializerFactory
    {
        // hashtable has better threading semantics than dictionary, honest!
        private static readonly Hashtable cache = new Hashtable();
        public static IMessageSerializer Create(Type t)
        {
            var found = (IMessageSerializer)cache[t];
            if(found != null) return found;
            lock(cache)
            {   // double-checked
                found = (IMessageSerializer)cache[t];
                if(found != null) return found;
                var types = new List<Type> { t };
                var mapper = new MessageMapper();
                mapper.Initialize(types);
                var serializer = new XmlMessageSerializer(mapper);
    
                serializer.Initialize(types);
    
                cache[t] = serializer;
                return serializer;
            }
        }
    }
