    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                dict[i] = i.ToString();
            }
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, dict);
                ms.Seek(0, SeekOrigin.Begin);
                var dict2 = ProtoBuf.Serializer.Deserialize<Dictionary<int, string>>(ms);
            }
        }
    }
