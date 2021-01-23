    public class DelayedDataGridTextColumn : DataGridTextColumn
    {
    	protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    	{
    		var textBlock = new c.TextBlock();
    		textBlock.SetValue(FrameworkElement.StyleProperty, ElementStyle);
    
    		Dispatcher.BeginInvoke(
    			DispatcherPriority.Loaded,
    			new Action<c.TextBlock>(x => x.SetBinding(c.TextBlock.TextProperty, Binding)),
    		textBlock);
    		return textBlock;
    	}
    }
