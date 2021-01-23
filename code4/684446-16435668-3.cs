    public class ScrollIntoViewBehavior : Behavior<ListView>
    {
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    		this.AssociatedObject.SelectionChanged += new SelectionChangedEventHandler(AssociatedObject_SelectionChanged);
    	}
    
    	protected override void OnDetaching()
    	{
    		base.OnDetaching();
    		this.AssociatedObject.SelectionChanged -= new SelectionChangedEventHandler(AssociatedObject_SelectionChanged);
    	}
    
    	private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    	{
    		if (sender is ListView)
    		{
    			ListView grid = (sender as ListView);
    			if (grid.SelectedItem != null)
    			{
    				grid.Dispatcher.BeginInvoke(() =>
    				{
    					grid.UpdateLayout();
    					grid.ScrollIntoView(grid.SelectedItem);
    				});
    			}
    		}
    	}
    }
