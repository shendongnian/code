    public class YourDbAccessClass {
        public IEnumerable<Comment> GetCommentsByStudentId(int id) {
            using (YourContextClass context = new YourContextClass()) {
                // Eager load Student with the .Include() method.
                var query = from comment in context.Comments.Include("Student")
                            where comment.StudentId == id
                            orderby comment.Created
                            select comment;
    
                return query.ToList();
            }
        }
    }
