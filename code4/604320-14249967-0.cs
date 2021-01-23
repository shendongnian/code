    public class Program
    {
        private static void Main(string[] args)
        {
            List<ItemA> itemATable = new List<ItemA>(new[]
                {
                    new ItemA {Id = "A1", IsDeleted = true},
                    new ItemA {Id = "A2", IsDeleted = false},
                });
            List<ItemB> itemBTable = new List<ItemB>(new[]
                {
                    new ItemB {Id = "B1", ItemAId = "A1", IsDeleted = true},
                    new ItemB {Id = "B2", ItemAId = "A1", IsDeleted = false},
                    new ItemB {Id = "B3", ItemAId = "A2", IsDeleted = true},
                    new ItemB {Id = "B4", ItemAId = "A2", IsDeleted = false},
                });
            var test = from a in itemATable
                       join b in itemBTable on a.Id equals b.ItemAId
                       where !a.IsDeleted && !b.IsDeleted
                       select new { a, b };
        }
    }
    public class ItemA
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ItemB
    {
        public string Id { get; set; }
        public string ItemAId { get; set; }
        public bool IsDeleted { get; set; }
    }
