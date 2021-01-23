        public A(SerializationInfo info, StreamingContext context)
        {
            //List<int> keys = info.GetValue("keys", typeof(List<int>)) as List<int>;
            //List<B> values = info.GetValue("values", typeof(List<B>)) as List<B>;
            //int count = keys.Count;
            //if (count == values.Count)
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        dic[keys[i]] = values[i];
            //    }
            //}
            dic = info.GetValue("mapping", typeof(Dictionary<int, B>)) as Dictionary<int, B>;
            list = info.GetValue("list", typeof(List<B>)) as List<B>;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("keys", dic.Keys.ToList(), typeof(List<int>));
            //info.AddValue("values", dic.Values.ToList(), typeof(List<B>));
            info.AddValue("mapping", dic, typeof(Dictionary<int, B>));
            List<B> listFromDic = new List<B>(dic.Values.ToList());
            info.AddValue("list", listFromDic, typeof(List<B>));
        }
