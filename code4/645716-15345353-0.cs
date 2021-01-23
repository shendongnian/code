    [ContractClassFor(typeof(IOpportunity))]
    public abstract class OpportunityContract : IOpportunity
    {
    
    	public ILocation Location
    	{
    		get { Contract.Ensures(Contract.Result<ILocation>() is IHierarchicalEntityWithParentNames || Contract.Result<ILocation>() is IHierarchicalEntityWithParentIds); }
    	}
    }
