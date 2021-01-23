    public class MyDict<K, V> : Dictionary<K, V>
    {
        public new void  Add(K k,V v)
        {
            base[k] = v;
        }
    }
---
    var obj = JsonConvert.DeserializeObject<MyDict<string, object>>(json);
