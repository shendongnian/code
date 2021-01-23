    public class myContentSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                VMBase vm = item as VMBase;
                switch (vm.Type)
                {
                    case myType.General:
                        return Application.Current.Resources["GeneralSettings"] as DataTemplate;
                    default:
                        return Application.Current.Resources["AdvancedSettings"] as DataTemplate;
                }
            }
            return null;
        }
    }
