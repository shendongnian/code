    public static bool GetIsTest(UIElement element)
    {
    	if (element == null)
    	{
    		throw new ArgumentNullException("element");
    	}
    
    	return (bool)element.GetValue(IsTestProperty);
    }
    
    public static void SetIsTest(UIElement element, bool value)
    {
    	if (element == null)
    	{
    		throw new ArgumentNullException("element");
    	}
    
    	element.SetValue(IsTestProperty, value);
    }
