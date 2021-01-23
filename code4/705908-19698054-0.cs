    namespace Asko.Web.Mvc.Infrastructure.Utils
    {
        public static class DropdownHelper
        {
            public static IEnumerable<SelectListItem> GetAllCategories()
            {
                var categories = category.GetAll();
                return categories.Select(x => new SelectListItem { Text = x.categoryName, Value = x.categoryId.ToString()}));
            }
        }
    }
