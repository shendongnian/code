    //This is also easier to unit test if you have conversions that are not 100% automappable.
    public class AddressEntityToAddress : TypeConverter<AddressEntity, Address>
    {
    	protected override Address ConvertCore(AddressEntity source)
    	{
    		if(source == null)
    		{
    			return null;
    		}
    		
    		var destination = new Address
    		{
    			Id = source.Id,
    			DisplayName = source.DisplayName,
    			AddressInfo = source.AddressInfo
    		};	
    
                //do other magic you may want during conversion time
    
    		return destination;
    	}
    }
