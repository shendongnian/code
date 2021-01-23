    public class GenericType : MarkupExtension
    {
         private readonly Type _of;
         public GenericType(Type of)
         {
             _of = of;
         }
         public override object ProvideValue(IServiceProvider serviceProvider)
         {
             return typeof(LocationTreeViewModel<>).MakeGenericType(_of);
         }
    }
