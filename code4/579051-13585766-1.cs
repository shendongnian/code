    public interface IEntity
    {
        int Id { get; set;}
        DateTime ValidFrom { get; set; }
        DateTime? ValidTo { get; set; }
    }
