    public class TenItemsInViewBehavior:Behavior<ListBox>
    {
        protected override OnAttached()
        {
            base.OnAttached();
            //AssociatedObject is the ListView object - you can bind to its events
            this.AssociatedObject. SelectionChanged+=CheckIfOnTenthItem;       
        }
        private void CheckIfOnTenthItem(object sender, eventargs e)
        {
            ....
        }
    }
