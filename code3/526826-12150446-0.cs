    public class GardenTemplateSelector : DataTemplateSelector
    {
    	public override DataTemplate SelectTemplate(object item, DependencyObject container)
    	{
    		var element = container as FrameworkElement;
    		if (element != null && item != null && item is GardenObject)
    		{	
    			if((item as GardenObject).image == "0")
    			{
    				return element.FindResource("TextTemplate") as DataTemplate;			
    			}
    			else
    			{
    				return element.FindResource("ItemTemplate") as DataTemplate;			
    			}			
    		}
    		
    		return null;
    	}
    }
