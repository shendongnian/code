    public class MyTemplateSelector : DataTempolateSelector
    {
         public override DataTemplate SelectTemplate(object item, DependencyObject container)
         {
            // here select temaplate, from dictionary for example, using item.GetType()
         }
    }
