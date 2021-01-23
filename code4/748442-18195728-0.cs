    public interface IEntity
    {
        int ID { get; set; }
        string Name { get; set; }
    }
    public class TypeOne : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set }
        public string BespokePropertyOne { get; set;}
    }
    public class TypeTwo : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float BespokePropertyTwo { get; set; }
    }
    static void Main(string[] args)
    {
        List<IEntity> entities = new List<IEntity>();
        entities.Add(new TypeOne() { ID = 1, Name = "Bob", BespokePropertyOne = "blablabla" });
        entities.Add(new TypeTwo() { ID = 2, Name = "Alice", BespokePropertyTwo = 5.4f });
        foreach (IEntity entity in entities)
        {
            Console.WriteLine("ID: {0} Name: {1}", entity.ID, entity.Name);
        }
    }
