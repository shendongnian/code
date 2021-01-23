    public class ShapeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CircleTemplate { get; set; }
        public DataTemplate SquareTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Shape shape = item as Shape;
            if (shape != null)
            {
                if (shape.Type == "Circle")
                    return this.CircleTemplate;
                else if (shape.Type == "Square")
                    return this.SquareTemplate;
                }
                return null;
            }
    }
