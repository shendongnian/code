    public class DelayedDataGridTextColumn : DataGridTextColumn
    {
    	protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    	{
    		var textBlock = new TextBlock();
    		textBlock.SetValue(FrameworkElement.StyleProperty, ElementStyle);
    
    		Dispatcher.BeginInvoke(
    			DispatcherPriority.Loaded,
    			new Action<TextBlock>(x => x.SetBinding(TextBlock.TextProperty, Binding)),
    		textBlock);
    		return textBlock;
    	}
    }
