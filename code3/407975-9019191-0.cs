public class Post
{
    public int ID { get; set; }
    public string Title { get; set; }
    public DateTime DateCreated { get; set; }
    public string Content { get; set; }
    public Blog Blog { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
