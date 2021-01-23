    namespace GoodHousekeeping.MVC.Models
    {
      public class ViewIngredientPageModel
      {
        public IEnumerable<ViewIngredientModel> ViewIngredientModels { get; set; }
        public IEnumerable<ViewIngredientCategoryModel> 
                              ViewIngredientCategoryModels { get; set; }
      }
    }
