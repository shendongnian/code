    using System.Linq;
    using System.Linq.Expressions;
    .
    .
    .
    public class PostRepository
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public IQueryable<Post> FindByParentId(int parentId)
        {
            return from post in db.Posts
                   where post.ParentID == parentId
                   select post;
        }
