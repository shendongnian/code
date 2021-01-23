    //Actually this implementation is edging on 
    //Unit Of Work
    interface IRepository<T>  
    {
        IQueryable<T> Query { get; }
        void Insert(T item);
        void SaveChanges();
    }
    
