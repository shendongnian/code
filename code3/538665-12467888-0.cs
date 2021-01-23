    public class Section
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sections = new List<Section>
                {
                    new Section { ID = 1, Name = "abc", ParentID = 0 },
                    new Section { ID = 2, Name = "def", ParentID = 1 },
                    new Section { ID = 3, Name = "ghi", ParentID = 1 },
                    new Section { ID = 4, Name = "jkl", ParentID = 0 },
                    new Section { ID = 5, Name = "mno", ParentID = 2 },
                    new Section { ID = 6, Name = "pqr", ParentID = 5 },
                    new Section { ID = 7, Name = "aaa", ParentID = 1 },
                    new Section { ID = 8, Name = "vwx", ParentID = 0 }
                };
            sections = sections.OrderBy(x => x.ParentID).ThenBy(x => x.Name).ToList();
            var stack = new Stack<Section>();
            // Grab all the items without parents
            foreach (var section in sections.Where(x => x.ParentID == default(int)).Reverse())
            {
                stack.Push(section);
                sections.RemoveAt(0);   
            }
            var output = new List<Section>();
            while (stack.Any())
            {
                var currentSection = stack.Pop();
                var children = sections.Where(x => x.ParentID == currentSection.ID).Reverse();
                foreach (var section in children)
                {
                    stack.Push(section);
                    sections.Remove(section);
                }
                output.Add(currentSection);
            }
        }
