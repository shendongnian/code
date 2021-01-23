    public class CustomItemsControl : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            FrameworkElement source = element as FrameworkElement;
            if (source != null)
            {
                source.SetBinding(Canvas.LeftProperty, new Binding { Path = new PropertyPath("X"), Mode = BindingMode.TwoWay });
                source.SetBinding(Canvas.TopProperty, new Binding { Path = new PropertyPath("Y"), Mode = BindingMode.TwoWay });
            }
        }
    }
