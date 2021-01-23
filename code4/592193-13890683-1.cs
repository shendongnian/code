    internal class CategoriesService : ICategoryService
    {
        public ICategoriesRepository CategoriesRepository { get; set; }
        public IWorkstationsRepository WorkstationsRepository { get; set; }
        
        // No constructor injection. I am too lazy for that, so the above properties 
        // are auto-injected with my custom ninject injection heuristic.
        public void ActivateCategory(int categoryId)
        {
            CategoriesRepository.FindOne(categoryId).IsActive = true;
        }
    }
