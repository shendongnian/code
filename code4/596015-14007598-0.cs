    public interface ICloneable<T>
    {
        T Clone();
    }
    public class Book : ICloneable<Book>
    {
        public Book Clone()
        {
            return new Book { /* set properties */ };
        }
    }
