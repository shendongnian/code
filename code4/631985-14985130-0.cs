    public class Category
    {
        public void LoadFromModel(CategoryViewModel model)
        {
            // Transfer properties from model to entity here
        }
    }
    public class CategoryService
    {
        public void UpdateCategory(CategoryViewModel model)
        {
            var category = _unitOfWork.CategoryRepository.FindBy(model.CategoryId);
            category.LoadFromModel(model);
            _unitOfWork.SaveChanges();
            model.CategoryId = category.CategoryId;
        }
    }
