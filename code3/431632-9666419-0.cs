    public interface IPerson
    {
        List<IBook> Books { get; private set; }
    }
    public interface IBook
    {
        string Name { get; private set; }
    }
    #endregion
    #region DAL/Entity Framework Auto Generated classes
    public class Person : IPerson
    {
        public List<Book> Books {get; private set;}
    }
    public class Book : IBook
    {
        public string Name { get; private set; }
    }
