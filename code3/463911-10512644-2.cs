    public partial class Category
    {
        public static Expression<Func<Category, bool>> ParentIsNullExpression
        {
            get 
            {
                return c => c.Category1 == null;
            }
        }
    }
