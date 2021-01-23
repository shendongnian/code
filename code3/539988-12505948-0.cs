    class Program
    {
        static void Main(string[] args)
        {
            List<BaseEntity> list = new List<BaseEntity>();
            DerivedOne d1 = new DerivedOne() { bp1 = 1, Name = "DerivedOne" };
            DerivedTwo d2 = new DerivedTwo() { bp1 = 2, Name = "DerivedTwo" }; 
            list.Add(d1);
            list.Add(d2);
        }
    }
    public class BaseEntity
    {
        public int bp1 { get; set; }
    }
    public class DerivedOne : BaseEntity
    {
        public string Name { get; set; }
    }
    public class DerivedTwo : BaseEntity
    {
        public string Name { get; set; }
    }
