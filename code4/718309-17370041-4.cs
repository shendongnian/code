    public interface IHasID 
    {
        int ID { get; }
    }
    public SomeTableName : IHasID { ... }
    public static Expression<Func<T, bool>> IDEquals1<T>() where T : IHasID
    {
         return x => x.ID == 1;
    }
