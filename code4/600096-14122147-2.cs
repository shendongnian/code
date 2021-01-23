    public class BlogcommentModel {
        /* All of the property declarations */
        public IList<BlogComment> ChildCommentList { get; set; }
        /* Constructor for the BlogcommentModel class */
        public BlogcommentModel() {
            ChildcommentList = new List<BlogComment>();
        }
    }
