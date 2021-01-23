    public class SomeItem
    {
        public int Sort { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return String.Format("Sort = {0},  Value = {1}", Sort, Value);
        }
    }
    public static class Test
    {
        public static void MoveUp()
        {
            List<SomeItem> list = InitializeList();
            list.MoveItem(3, 1, x => x.Sort, (x, i) => x.Sort = i);
        }
        public static void MoveDown()
        {
            List<SomeItem> list = InitializeList();
            list.MoveItem(1, 3, x => x.Sort, (x, i) => x.Sort = i);
        }
        private static List<SomeItem> InitializeList()
        {
            return new List<SomeItem> {
                new SomeItem{ Sort = 1, Value = "foo1" },
                new SomeItem{ Sort = 2, Value = "foo2" },
                new SomeItem{ Sort = 3, Value = "foo3" },
                new SomeItem{ Sort = 4, Value = "foo4" },
                new SomeItem{ Sort = 5, Value = "foo5" }
            };
        }
    }
