    public interface IHaveAuthor
    {
        int AuthorId { get; set; }
    }
    //Note that the interface is already implemented in auto-genereated part.
    //Or if it's Code First, just specify it directly on your classes.
    public partial class Book : IHaveAuthor
    {
    }
    public partial class Article: IHaveAuthor
    {
    }
