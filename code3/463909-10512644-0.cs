    public partial class Category
    {
        public static Expression<Func<Category, Category>> ParentIsNullExpression
        {
            get 
            {
                return c => c.Category1 == null;
            }
        }
    }
