    class CustomPanel : Panel
    {
        //Children of this panel should be of type GridViewItem (which is the ItemContainer for the
        //ItemsControl)
    
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (var child in this.Children)
            {
                var interior = (UIElement)VisualTreeHelper.GetChild(child, 0);
                interior.Measure(availableSize);
                
                if (interior.DesiredSize.Width == 0 && interior.DesiredSize.Height == 0)
                    //Skip this item
                else
                {
                    child.Measure(availableSize);
                    //Update the total measure of the panel with child.DesiredSize...
                }
    
                //Return the total calculated size
            }
        }
    
        protected Size override ArrangeOverride(Size finalSize)
        {
            foreach (var child in this.Children)
            {
                var interior = (UIElement)VisualTreeHelper.GetVisualChild(child, 0);
    
                if (interior.DesiredSize.Width == 0 || interior.DesiredSize.Height == 0)
                    //Skip this item
                else
                    //Call child.Arrange with the appropriate arguments and update the total size
                    //used...
    
                //Return the total size used
            }
        }
    }
