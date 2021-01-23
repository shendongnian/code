    public class GridViewDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is GridViewRow)
            {
                GridViewRow  rowitem = item as GridViewRow;
                
                // Here's where you compare with actual selected number (change 1 with the method call to obtain it.
                if (GridViewRow.RowIndex == 1) 
                    return
                        element.FindResource("SpecialBackgroundRowTemplate") as DataTemplate;
                else 
                    return
                        element.FindResource("NormalBackgroundRowTemplate") as DataTemplate;
            }
            return null;
        }
    }
