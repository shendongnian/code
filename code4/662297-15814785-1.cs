    public interface IHasId
    {
        int Id { get; }
    }
    public class User : IHasId { ... }
    public class Vehicle : IHasId { ... }
    public static int GetId<T>(T entity) where T : IHasId
    {
        return entity.Id;
    }
