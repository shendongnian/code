    public class Program
    {
        public static void Main(string[] args)
        {
            List<Tag> tags = new List<Tag>() { new Tag() { Name ="tag1"}, new Tag() { Name = "tag4"} , new Tag() { Name = "tag3"}};
            string[] sTags = new[] {"tag1", "tag2", "tag3"};
            
            IEnumerable<Tag> result = tags.Where(t => sTags.Contains(t.Name));
        }
    }
    public class Tag
    {
        public string Name { get; set; }
    }
