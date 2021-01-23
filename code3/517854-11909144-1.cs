    public class CategoryItemsViewModel
    {
        public ICategoriesRepository categoriesRepository;
    
        public IEnumerable<Categories> GetCategories()
        {
            // This is to instantiate your repository.  It may be a better idea to do this
            // when it is declared, above.
            categoriesRepository = new CategoriesRepository();
            var cat = categoriesRepository.Categories;
    
            return cat;
    
        }
    }
