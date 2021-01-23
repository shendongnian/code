    public class ScrollingListBox : ListBox
    {
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int newItemCount = e.NewItems.Count; 
 
            if(newItemCount > 0) 
                this.ScrollIntoView(e.NewItems[newItemCount - 1]);
            base.OnItemsChanged(e);
        } 
    }
