    public class Comment
    {
        [Key]
        public int Comment_Id { get; set; }
        public string Text { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Name { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
