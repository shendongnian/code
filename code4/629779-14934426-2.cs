    public static String GetElementPropertyValue(HtmlElement element, String property)
    {
    	if(element == null)
    		throw new ArgumentNullException("element");
    	if(String.IsNullOrEmpty(property))
    		throw new ArgumentNullException("property");
    
    	String result = element.GetAttribute(property);
    	if(String.IsNullOrEmpty(result))
    	{//В MSIE 9 получить свойство через DomElement не получается. Т.к. там он ComObject.
    		var objProperty = element.DomElement.GetType().GetProperty(property);
    		if(objProperty != null)
    		{
    			Object value = objProperty.GetValue(element.DomElement, null);
    			result = value == null ? String.Empty : value.ToString();
    		}
    	}
    	return result;
    }
