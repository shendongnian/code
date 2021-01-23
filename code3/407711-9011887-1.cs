    public class OptionsViewModel : ViewModelBase
    {
    
      public OptionsViewModel()
      {
         IsBusy = True;
         var context = new MyDomainContext();
         _Tags = context.Tags;
         //if called elsewhere but from ctor, make sure context.IsLoading is false;
         //The Load method is throwing an exception if re-loading when a load is on.
         //Debug.Assert(!context.IsLoading);
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
