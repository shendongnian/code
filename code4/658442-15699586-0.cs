    public interface IEntityContext
    {
        IQueryable Departments { get; set;}
        IQueryable Employees { get; set;}
    }
