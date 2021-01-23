    using BaseContext = BaseLibrary.MyContext;
    
    public class MyExtendedContext : BaseContext
    {
        public new DbSet<Person> Persons { get; set; }
    }
