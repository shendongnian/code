    public class CollectionConverter: ITypeConverter<List<Source>, List<Destination>>
    {
    	public List<Destination> Convert(ResolutionContext context)
    	{
    		var destinationCollection = (List<Destination>)context.DestinationValue;
    		if(destinationCollection == null)
    			destinationCollection = new List<Destination>();
    		var sourceCollection = (List<Source>)context.SourceValue;
    		foreach(var source in sourceCollection)
    		{
    			var matchedDestination = destinationCollection.FirstOrDefault(d=>d.Id == source.Id);
    			if(matchedDestination != null)
    				Mapper.Map(source, matchedDestination);
    			else 	
    				matchedDestination = Mapper.Map<Destination>(source);
    			destinationCollection.Add(matchedDestination);
    		}
    		return destinationCollection;
    	}
    }
