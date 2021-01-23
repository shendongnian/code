        public A(SerializationInfo info, StreamingContext context)
        {
            dic = info.GetValue("mapping", typeof(Dictionary<int, B>)) as Dictionary<int, B>;
            list = info.GetValue("list", typeof(List<B>)) as List<B>;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("mapping", dic, typeof(Dictionary<int, B>));
            List<B> listFromDic = new List<B>(dic.Values.ToList());
            info.AddValue("list", listFromDic, typeof(List<B>));
        }
