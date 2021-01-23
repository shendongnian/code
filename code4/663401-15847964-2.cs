    public static class CategoriesExtensionMethods
    {
        public static Categories GetParentCategory(this Categories category)
        {
            Categories[] parents = 
            {
                Categories.A,
                Categories.B,
                Categories.C,
                Categories.D,
                Categories.E,
                Categories.F,
                Categories.G,
                Categories.H,
            };
    
            Categories? parent = parents.SingleOrDefault(e => category.HasFlag(e));
            if (parent != null)
                return (Categories)parent;
            return Categories.None;
        }
    
        public static string ToStringWithParent(this Categories category)
        {
            var parent = GetParentCategory(category);
            if (parent == Categories.None)
                return category.ToString();
            return string.Format("{0} | {1}", parent.ToString(), category.ToString());
        }
    }
