    public static class ViewModelProfileExtensions
    {
    	public static CustomerWithOrdersModel ToModel(this Customer customer)
    	{
    		return Mapper.Map<CustomerWithOrdersModel>(customer);
    	}
    	
    	public static Customer ToEntity(this CustomerWithOrdersModel customerWithOrdersModel)
    	{
    		return Mapper.Map<Customer>(customerWithOrdersModel);
    	}
    }
