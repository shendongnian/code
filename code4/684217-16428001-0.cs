    public interface ISomeInterface
    {
        String Title { get; set; }
        String Url { get; set; }
    }
    public class SecondClass : ISomeInterface
    {
        public String Title { get; set; }
        public String Url { get; set; }
    }
    public class FirstClass : ISomeInterface
    {
        public String Title { get; set; }
        public String Url { get; set; }
    }
    public class SomeClassCollection<T> : List<T> where T: ISomeInterface, new()
    {
        public SomeClassCollection(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                this.Add(new T()
                {
                    Title = (String)row["Title"]
                });
            }
        }
    }
        private static void Main()
        {
            DataTable table = new DataTable();
            SomeClassCollection<FirstClass> collection = new SomeClassCollection<FirstClass>(table);
        }
