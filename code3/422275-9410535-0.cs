     class Program
    {
        static void Main(string[] args)
        {
            List<Test> testData = new List<Test>()
            {
                new Test(1,"Test"),
                new Test(2, "Test"),
                new Test(2, "Test")
            };
            var result = testData.Where(x => x.Id > 1).Distinct(new MyComparer());
        }
    }
    public class MyComparer : IEqualityComparer<Test>
    {
        public bool Equals(Test x, Test y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Test obj)
        {
            return string.Format("{0}{1}", obj.Id, obj.Name).GetHashCode();
        }
    }
    public class Test
    {
        public Test(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
