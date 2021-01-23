    class Search
    {
       public Books[] GetBooks(IAuthor author, Func<IAuthor, bool> filter){
           // ...
        }
    }
    search.GetBooks(author, a => a.IsNovelist)
