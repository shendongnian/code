    public class Program
    {
        public static void Main(string[] args)
        {
            List<Tag> tags = new List<Tag>() {new Tag() {TagID = "tag1"}, new Tag() {TagID = "tag4"}, new Tag() {TagID = "tag3"}};
            string[] tagIds = new[] {"tag1", "tag2", "tag3"};
            IEnumerable<Tag> result = tags.Where(tag => tagIds.Contains(tag.TagID));
        }
    }
    public class Tag
    {
        public string TagID { get; set; }
    }
