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
    			Destination matchedDestination = null;
    			
    			foreach(var destination in destinationCollection)
    			{
    				if(destination.Id == source.Id)
    				{
    					Mapper.Map(source, destination);
    					matchedDestination = destination;
    					break;
    				}
    			}
    			if(matchedDestination == null)
    				destinationCollection.Add(Mapper.Map<Destination>(source));
    		}
    		return destinationCollection;
    	}
    }
