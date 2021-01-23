    public class BaseClass
    {
        public int Id{get;set;}
    }
    public class Position : BaseClass
    {
        public string Name {get;set;}
    }
    public class Comaprer<T> : IEqualityComparer<T>
        where T:BaseClass
    {
        public bool Equals(T x, T y)
        {
            return (x.Id == y.Id);
        }
        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Position> all = new List<Position> { new Position { Id = 1, Name = "name 1" }, new Position { Id = 2, Name = "name 2" }, new Position { Id = 1, Name = "also 1" } };
            var distinct = all.Distinct(new Comaprer<Position>());
            foreach(var d in distinct)
            {
                Console.WriteLine(d.Name);
            }
            Console.ReadKey();
        }
    }
