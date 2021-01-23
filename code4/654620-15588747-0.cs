    class ToolTipServiceHelper
    {       
    	public void EnumVisual(Visual myVisual)
    	{
    		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
    		{
    			Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);                
    			ToolTipService.SetShowOnDisabled(childVisual, true);
    			EnumVisual(childVisual);
    		}
    	}
    }
