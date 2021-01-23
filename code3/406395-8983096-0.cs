    public class AdventureWorksRepository
    {
      private readonly AdventureWorksContext context;
      public AdventureWorksRepository(AdventureWorksContext context)
      {
        if(context == null) throw new ArgumentNullException("context");
        this.context = context;
      }
    }
