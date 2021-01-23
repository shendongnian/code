        public class Group
        {
            public Group()
            {
                Tags = new List<Tag>();
            }
            public string Name { get; set; }
            public List<Tag> Tags { get; set; }
        }
        public class Tag
        {
            public string Name { get; set; }
        }
