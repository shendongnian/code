    public static class Extension
    {
        public static IQueryable<TEntity> WhereCostCenter<TEntity>(
            this IQueryable<TEntity> queryable, int costCenterID)
            where TEntity : IHaveCostCenterID
        {
            var result =
                queryable.Where(e => e.CostCenterID == costCenterID);
            return result;
        }
    }
    public interface IHaveCostCenterID
    {
        int CostCenterID { get; set; }
    }
    public partial class Employee : IHaveCostCenterID
    {
        public int CostCenterID { get; set; }
    }
    public partial class Department : IHaveCostCenterID
    {
        public int CostCenterID { get; set; }
    }
