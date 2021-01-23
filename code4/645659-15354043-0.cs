    public class OrientationTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            // cast item to your custom item class
            var customItem = item as CustomItem;
            if (customItem == null)
                return null;
            string templateName = String.Empty;
            if (customItem.Width > customItem.Height
            {
                // image is horizontal
                templateName = "HorizontalItemTemplate";
            }
            else
            {
                templateName = "VerticalItemTemplate";
            }
            object template = null;
            // find template in App.xaml
            Application.Current.Resources.TryGetValue(templateName, out template);
            return template as DataTemplate;
        }
    }
