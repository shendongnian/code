    public class OpenGenericTypeDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item,
                                                    DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (item != null && element != null)
            {
                if (item.GetType().IsGenericType)
                {
                    var genericTypeDefinition = item.GetType()
                                                    .GetGenericTypeDefinition();
                    var key = new DataTemplateKey(genericTypeDefinition);
                    return element.TryFindResource(key) as DataTemplate;
                }
            }
            return null;
        }
    }
