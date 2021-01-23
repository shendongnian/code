     [Validator(typeof(BlogPostValidator))]
    public partial class BlogPostModel : BaseNopEntityModel
    {
        public BlogPostModel()
        {
            Tags = new List<string>();
            Comments = new List<BlogCommentModel>();
            AddNewComment = new AddBlogCommentModel();
            ChildCommentList = new List<BlogComment>();
        }
        public string SeName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool AllowComments { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime CreatedOn { get; set; }
        public IList<string> Tags { get; set; }
        public IList<BlogCommentModel> Comments { get; set; }
        public AddBlogCommentModel AddNewComment { get; set; }
        //Netra
        public int CommentParentID { get; set; }
        public IList<BlogComment> ChildCommentList { get; set; }//netra
       // public BlogCommentModel blogcommentmodel { get; set; }
    }
