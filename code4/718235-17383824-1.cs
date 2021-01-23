    public interface IEntity
    {
        int id { get; set; }
    }
    public class Person: IEntity
    {
        public int id { get; set; }
    }
    public class Employee : IEntity
    {
        public int id { get; set; }
    }
        public static List<IEntity> Order<T>(List<IEntity> filtered, List<IEntity> full)
        {
            HashSet<int> ids = new HashSet<int>(filtered.Select(x => x.id));
            return full.OrderByDescending(x => ids.Contains(x.id)).ThenBy(x => !ids.Contains(x.id)).ToList();
        }
