    public interface ICategory
    {
        int Id { get; }
        int ParentId { get; }
    }
    public class Category : ICategory
    {
        int id;
        int parentId;
        public int Id { get { return id; }}
        public int ParentId { get { return parentId; }}
    }
