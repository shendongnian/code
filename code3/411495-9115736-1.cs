	public static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
	{
 	   RouteValueDictionary dictionary = new RouteValueDictionary();
  	  if (htmlAttributes != null)
  	  {
   	     foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(htmlAttributes))
   	     {
    	        dictionary.Add(descriptor.Name.Replace('_', '-'), descriptor.GetValue(htmlAttributes));
     	   }
   	 }
    	return dictionary;
     }
