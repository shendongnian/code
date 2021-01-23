    public class User : IHasID { ... }
    public class Vehicle : IHasID { ... }
    public interface IHasId
    {
        int Id { get; }
    }
    public static int GetId<T>(T entity) where T : IHasId
    {
        return entity.Id;
    }
