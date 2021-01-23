    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ModelContainer db= new ModelContainer();
    
        public IQueryable<Categories> Categories 
        { 
            get
            {
                return this.db.Categories;
            }
        }
    
        public void SaveCategory(Categories category)
        {
            // TODO
        }
    
        public void DeleteCategory(Categories category)
        {
            // TODO
        }
    }
