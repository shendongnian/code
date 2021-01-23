    public interface IHaveAuthor
    {
        int AuthorId { get; set; }
    }
    //Note that the interface is already implemented in auto-genereated part.
    //Or if it's Code First, just specify it directly on your classes.
    public partial Book : IHaveAuthor
    {
    }
    public partial Article: IHaveAuthor
    {
    }
