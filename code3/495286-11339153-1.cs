    public abstract class QueryLibrary
    {
        protected readonly EntityModel db;
        protected QueryLibrary(EntityModel db)
        {
            this.db = db;
        }
    }
