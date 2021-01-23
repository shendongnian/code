    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
    }
