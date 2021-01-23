    abstract class AbstractAttributes<T, K>
    {
        protected List<K> Attributes = new List<K>();
        public AbstractAttributes()
        {
            foreach (var member in typeof(T).GetMembers())
            {
                foreach (K attribute in member.GetCustomAttributes(typeof(K), true)) Attributes.Add(attribute);                
            }
        }
    }
