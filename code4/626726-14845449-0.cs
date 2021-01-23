    public interface IHaveCostCenterID
    {
        public int CostCenterID {get; set;}
    }
    
    public partial class Employee : IHaveCostCenterID
    {
    }
    
    public partial class Department : IHaveCostCenterID
    {
    }
    
    public static IQueryable<IHaveCostCenterID> WhereCostCenter(this IQueryable<IHaveCostCenterID> queryable, int costCenterID)
    {
        var result = queryable
            .Where(e => e.CostCenterID ==  costCenterID);
        return result;
    }
