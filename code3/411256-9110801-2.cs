    public class DomainContext : DbContext, IDomainContext
    {
        static DomainContext()
        {
            // register the DbIncluder for making sure the right call to include is made (standard is null)
            QueryableIncludeExtensions.Includer = new DbIncluder();
        }
