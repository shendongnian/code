    ...
    return query.ToList();
    [ServiceContract]
    public interface ICatalog
    {
        [OperationContract]
        List<Book> GetBooks();
     }
