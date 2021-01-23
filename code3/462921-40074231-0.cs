    public class Store
    {
        ...
        public static Expression<Func<Store, bool>>
            SafeSearchName(string sWhat)
        {
            return LinqExprHelper.NewExpr(
                (Store s) => s.Name != null && s.Name.ToLower().Contains(sWhat)
            );
        }
        public static Expression<Func<Store, bool>>
            SafeSearchDesc(string sWhat)
        {
            return LinqExprHelper.NewExpr(
                (Store s) => s.Description != null && s.Description.ToLower().Contains(sWhat)
            );
        }
    }
