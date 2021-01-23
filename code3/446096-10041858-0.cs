    internal static IList<ParentChild> GetAllCategoriesAndSubcategories()
        {
            lock (Context) // lock is implemented just before asking question, to check whether it can solve the issue or not...
            {
                return (from p in Context.Categories
                       let relatedchilds = (from c in Context.SubCategories
                                            where c.CategoryId == p.Id
                                            select c).Take(5)
                       select new ParentChild
                       {
                           Parent = p,
                           Childs = relatedchilds
                       }).ToList();
            }
        }
