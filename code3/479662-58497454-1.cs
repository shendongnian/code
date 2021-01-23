    class Program
    {
        static void Main(string[] args)
        {
            List<TestClass> lst = new List<TestClass>();
            for (int i = 1; i <= 10000000; i++)
            {
                TestClass obj = new TestClass() {
                    ID = i,
                    Name = "Name" + i.ToString()
                };
                lst.Add(obj);
            }
            DateTime start = DateTime.Now;
            foreach (var obj in lst)
            {
                //obj.ID = obj.ID + 1;
                //obj.Name = obj.Name + "1";
            }
            DateTime end = DateTime.Now;
            var first = end.Subtract(start).TotalMilliseconds;
            start = DateTime.Now;
            for (int j = 0; j<lst.Count;j++)
            {
                //lst[j].ID = lst[j].ID + 1;
                //lst[j].Name = lst[j].Name + "1";
            }
            end = DateTime.Now;
            var second = end.Subtract(start).TotalMilliseconds;
        }
    }
    
    public class TestClass
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
