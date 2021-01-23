    public static Book FindLastBookPublishedBefore(IEnumerable<Book> books, 
                                                   DateTime date)
    {
     return books.FindLast(x => x.Publish_date < date);
    }
    
