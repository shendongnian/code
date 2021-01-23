    public class CategoryTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Cat1Template { get; set; }
        public DataTemplate Cat2Template { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return ((CategoryBase)item).HasSubCat1 ? Cat1Template : Cat2Template;
        }
    }
