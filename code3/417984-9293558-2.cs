    [Serializable()]
    public class A : ISerializable, IDeserializationCallback 
    {
        Dictionary<int, B> dic = new Dictionary<int, B>();
        List<B> list = new List<B>();
        private List<int> keys = new List<int>();
        public A()
        {
            for (int i = 0; i < 4; i++)
            {
                dic.Add(i, new B(i));
                list.Add(new B(i));
            }
        }
        public void PrintData()
        {
            foreach (KeyValuePair<int, B> kvp in dic)
            {
                Console.WriteLine("Dictionary: " + kvp.Key.ToString() + "-" + ((kvp.Value != null) ? kvp.Value.ToString() : "Null"));
            }
            foreach (B b in list)
            {
                Console.WriteLine("List: " + b.ToString());
            }
        }
        public A(SerializationInfo info, StreamingContext context)
        {
            keys = info.GetValue("keys", typeof(List<int>)) as List<int>;
            List<B> values = info.GetValue("values", typeof(List<B>)) as List<B>;
            list = info.GetValue("list", typeof(List<B>)) as List<B>;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("keys", dic.Keys.ToList(), typeof(List<int>));
            info.AddValue("values", dic.Values.ToList(), typeof(List<B>));
            List<B> listFromDic = new List<B>(dic.Values.ToList());
            info.AddValue("list", listFromDic, typeof(List<B>));
        }
        public void OnDeserialization(object sender)
        {
            dic = new Dictionary<int, B>();
            int count = keys.Count;
            if (count == list.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    dic[keys[i]] = list[i];
                }
            }
        }
    }
