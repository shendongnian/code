     public class MainTabViewDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            switch ((item as TabInfoEntity).TabIndex)
            {
                case 1:
                    {
                        return element.FindResource("Dashboard") as DataTemplate;
                    }
                case 2:
                    {
                        return element.FindResource("SystemHealth") as DataTemplate;
                    }
            }
            return null;
        }
    }
