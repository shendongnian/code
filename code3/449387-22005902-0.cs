    public static class ProductCssHelper
    {
        public static string IsDeleted(bool IsDeleted)
        {
            return IsDeleted ? "deleted" : String.Empty
        }
    
        public static string IsAction(bool IsAction)
        {
            return IsAction ? "active-action" : "inactive-action"
        }
    }
