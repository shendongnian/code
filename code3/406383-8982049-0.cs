    public class Foo
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    
    public static class Extension
    {
        public static Foo Item(this List<Foo> list, string item)
        {
            return list.FirstOrDefault(p => p.ID == item);
        }
    }
