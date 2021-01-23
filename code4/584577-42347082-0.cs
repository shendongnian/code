    using NHibernate.Linq;
    
    ...
    
    public static class CustomLinqExtensions
    {
        [LinqExtensionMethod("dbo.BasicSearch")]
        public static bool BasicSearch(this string searchField, string pattern)
        {
            // No need to implement it in .Net, unless you wish to call it
            // outside IQueryable context too.
            throw new NotImplementedException("This call should be translated " +
                "to SQL and run db side, but it has been run with .Net runtime");
        }
    }
