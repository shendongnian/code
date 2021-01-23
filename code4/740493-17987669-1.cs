    class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> list = new List<dynamic>();
            dynamic
                t1 = new ExpandoObject(),
                t2 = new ExpandoObject();
            t1.Address = "address1";
            t1.ID = 132;
            t2.Address = "address2";
            t2.ID = 133;
            t2.Name = "someName";
            t2.DateTime = DateTime.Now;
            list.AddRange(new[] { t1, t2 });
            // later in your code
            list.Select((obj, index) =>
                new { index, obj }).ToList().ForEach(item =>
            {
                Console.WriteLine("Object #{0}", item.index);
                ((IDictionary<string, object>)item.obj).ToList()
                    .ForEach(i =>
                    {
                        Console.WriteLine("Property: {0} Value: {1}",
                            i.Key, i.Value);
                    });
                Console.WriteLine();
            });
            // or maybe generate JSON
            var s = JsonSerializer.Create();
            var sb=new StringBuilder();
            var w=new StringWriter(sb);
            var items = list.Select(item =>
            {
                sb.Clear();
                s.Serialize(w, item);
                return sb.ToString();
            });
            items.ToList().ForEach(json =>
            {
                Console.WriteLine(json);
            });
        }
    }
