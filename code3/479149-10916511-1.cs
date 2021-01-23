    public class IntKeyEntity : IEntityBase<int>
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public class StringKeyEntity : IEntityBase<string>
    {
        string Id { get; set; }
        string Name { get; set; }
    }
    //etc
