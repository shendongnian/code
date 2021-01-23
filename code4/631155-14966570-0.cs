    public class DescendantEntity : EntityBase, IDescendatnEntity
    {
    
       public DescendantEntity(IBusinessModel model, IAppContext context, ...additional params...)
       {
       }
       public DescendantEntity(IBusinessModel model, IAppContext context)
           this(model, context, ...additional params defaults...)
       {
       }
    }
