    public static string ToQueryString(this ModelMetadata modelMetadata)
    {
    	if(modelMetadata.Model == null)
    		return string.Empty;
    		
    	var parameters = modelMetadata.Properties.SelectMany (mm => mm.SelectPropertiesAsQueryStringParameters(null));
    	var qs = string.Join("&",parameters);
    	return "?" + qs;
    }
    
    private static IEnumerable<string> SelectPropertiesAsQueryStringParameters(this ModelMetadata modelMetadata, string prefix)
    {
    	if(modelMetadata.Model == null)
    		yield break;
    		
    	if(modelMetadata.IsComplexType)
    	{
    		IEnumerable<string> parameters;
    		if(typeof(IEnumerable).IsAssignableFrom(modelMetadata.ModelType))
    		{
    			parameters = modelMetadata.GetItemMetadata()
    									.Select ((mm,i) => new {
    										mm, 
    										prefix = string.Format("{0}{1}[{2}]", prefix, modelMetadata.PropertyName, i)
    									})
    									.SelectMany (prefixed =>
    										prefixed.mm.SelectPropertiesAsQueryStringParameters(prefixed.prefix)
    									);			
    		} 
    		else 
    		{
    			parameters = modelMetadata.Properties
    						.SelectMany (mm => mm.SelectPropertiesAsQueryStringParameters(string.Format("{0}{1}", prefix, modelMetadata.PropertyName)));
    		}
    
    		foreach (var parameter in parameters)
    		{
    			yield return parameter;
    		}
    	} 
    	else 
    	{
    		yield return string.Format("{0}{1}{2}={3}",
    			prefix, 
    			prefix != null && modelMetadata.PropertyName != null ? "." : string.Empty,
    			modelMetadata.PropertyName, 
    			modelMetadata.Model);
    	}
    }
    
    // Returns the metadata for each item from a ModelMetadata.Model which is IEnumerable
    private static IEnumerable<ModelMetadata> GetItemMetadata(this ModelMetadata modelMetadata)
    {
    	if(modelMetadata.Model == null)
    		yield break;
    		
    	var genericType = modelMetadata.ModelType
    						.GetInterfaces()
    						.FirstOrDefault (x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
    						
    	if(genericType == null)
    		yield return modelMetadata;
    		
    	var itemType = genericType.GetGenericArguments()[0];
    	
    	foreach (object item in ((IEnumerable)modelMetadata.Model))
    	{
    		yield return ModelMetadataProviders.Current.GetMetadataForType(() => item, itemType);
    	}
    }
