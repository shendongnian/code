    public class Alias : Dictionary<long, object>
    {
        public Alias() {}
        public Alias(Dictionary<long, object> dictionary)
        {
            foreach(var kvp in dictionary)
                Add(kvp);
        }
        public static implicit operator Alias (Dictionary<long, object> dictionary)
        {
            return new Alias(dictionary);
        }
    }
