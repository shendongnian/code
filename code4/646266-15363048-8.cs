    public class DropBehavior : Behavior<TextBlock>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseUp += AssociatedObject_MouseUp;
        }
    
        private void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Handle what happens on mouse up
                
            // Check requirements, has data been dragged, etc.
            // Get underlying data, now simply as the DataContext of the AssociatedObject
            var cellData = AssociatedObject.DataContext;
    
        }
    }
