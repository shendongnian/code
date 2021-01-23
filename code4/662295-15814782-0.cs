    public interface IEntity
    {
        int Id { get; set; }
    }
    
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
    
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
    public static int GetId<T>(T entity) where T : IEntity
    {
        return entity.Id;
    }
