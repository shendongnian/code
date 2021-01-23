    public class OptionsViewModel : ViewModelBase
    {
    
      public OptionsViewModel()
      {
         var context = new MyDomainContext();
         _Tags = context.Tags;
         context.Load(
            context.GetTagsQuery(),
            (op) =>
            {
              if(op.HasError && !op.IsErrorHandled) op.MarkErrorAsHandlere();
              IsBusy = false;
            },
            null);
      }
    
      private readonly Ienumerable<Tag> _Tags;
      public Ienumerable<Tag> Tags
      {
        get
        {
          return _Tags;
        }
      }
    
    }
