    public class SomeSqlObject : SomeBaseClass
    {
      public SomeSqlObject(ArchiveTypeValues archiveType)
            : base(delegate()
            {
                switch (archiveType)
                {
                    case ArchiveTypeValues.CurrentIssues:
                    case ArchiveTypeValues.Archived:
                        return Queries.ProductQueries.ProductQueryActive;
                    case ArchiveTypeValues.AllIssues:
                        return     string.Format(Queries.ProductQueries.ProductQueryActiveOther, (int)archiveType);
                    default:
                        throw new InvalidOperationException("Unknown archiveType");
                };
            })
        {
            //Derived Constructor code here!
        }
    
    }
