    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<Group> Subgroups { get; set; }
        public Group()
        {
            this.Subgroups = new List<Group>();
        }
    }
    class Program
    {
        static void Main()
        {
            Group[] groups = new Group[]
            {
                new Group { Id = 1, Name = "Group 1", ParentId = null },
                new Group { Id = 2, Name = "Group 2", ParentId = null },
                new Group { Id = 3, Name = "SubGr 1-1", ParentId = 1 },
                new Group { Id = 4, Name = "SubGr 1-2", ParentId = 1 },
                new Group { Id = 5, Name = "SubGr 2-1", ParentId = 2 },
                new Group { Id = 6, Name = "Group 3", ParentId = null },
                new Group { Id = 7, Name = "SubGr 1-2-1", ParentId = 4 }
            };
            foreach (Group g in groups)
                if (g.ParentId.HasValue)
                    groups.Single(group => group.Id == g.ParentId.Value).Subgroups.Add(g);
            var rootgroups = groups.Where(g => g.ParentId == null);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Console.WriteLine(js.Serialize(rootgroups));
        }
    }
