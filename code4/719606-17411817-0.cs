    public abstract class TenantEntity
    {
    public virtual int TenantId {get;set;}
    
    }
    
    
    public class Role : TenantEntity
    {
    public virtual int TenantId {get;set;
    public virtual IList<Capability> Capabilities { get; set; }
    }
    
    public class FilterHasManyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
    		if (instance.ChildType.IsSubclassOf(typeof(TenantEntity)))
            {
    				instance.ApplyFilter<TenantFilter>("tenantid = :tid");	
            }
        }
    }
