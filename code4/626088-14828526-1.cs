    public class Tasks:Itask
        {
            CategoryDataEntities db = new CategoryDataEntities();
    
            public IQueryable<Category> CategoryList()
            {
                IQueryable<Category> categoryLiist = db.Categories.AsQueryable();
    
                return categoryLiist;
            }
        }
