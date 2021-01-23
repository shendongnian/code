    public interface IBookShelf<T> where T : IBook
    {
        long Stuff { get; set; }
        List<T> Books { get; set; }
    }
