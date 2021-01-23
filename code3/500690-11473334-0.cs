    public abstract class BookBase : IBook<FormatBase>, IBook
    {                
        public abstract FormatBase GetFormat();
    
        object IBook.GetFormat()
        {
            return GetFormat();
        }
    }
