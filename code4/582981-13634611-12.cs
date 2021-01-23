    public class KVPList<T> : List<KeyValuePair<string, T>> 
    {
        public void Add(string key, T value)
        {
            base.Add(new KeyValuePair<string,T>(key, value));
        }
    }
    var abc = new KVPList<KVPList<KVPList<bool>>> { 
        { "A", new KVPList<KVPList<bool>> {
            { "B", new KVPList<bool> {
                { "C", true }}
            }}
        }};
