    [Serializable]
    internal sealed class Test2 : Dictionary<int, int>
    {
        internal Test2()
        {
        }
        private Test2(SerializationInfo info, StreamingContext context)
        {
            var data = (List<Tuple<string, string>>)
                       info.GetValue("data", typeof(List<Tuple<string, string>>));
            foreach (var item in data)
                Add(int.Parse(item.Item1), int.Parse(item.Item2));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var data = new List<Tuple<string, string>>();
            foreach (var item in this)
                data.Add(Tuple.Create(item.Key.ToString(), item.Value.ToString()));
            info.AddValue("data", data, typeof(List<Tuple<string, string>>));
        }
    }
