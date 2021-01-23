    public class IsWashedStyleSelector : DataTemplateSelector
    {
        public DataTemplate TrueStyle { get; set; }
        public DataTemplate FalseStyle { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            TestClass targetItem = item as TestClass;
            if (targetItem != null)
            {
                return targetItem.IsWashed ? TrueStyle : FalseStyle;
            }
            return base.SelectTemplate(item, container);
        }
    }
