    public class ScrollIntoViewBehavior:Behavior<ListBox>
	{
		protected override void OnAttached()
		{
			AssociatedObject.SelectionChanged += new SelectionChangedEventHandler(AssociatedObject_SelectionChanged);
		}
		void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0)
			{
				(sender as ListBox).ScrollIntoView(e.AddedItems[0]);
			}
		}
	}
