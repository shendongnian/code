    namespace GoodHousekeeping.MVC.Models
    {
      public class ViewIngredientModel
      {
        public int? IngredientId { get; set; }
        [DisplayName("Ingredient Name")]
        public string Name { get; set; }
        public int IngredientCategoryId { get; set; }
        #region navigation
        public ViewIngredientCategoryModel IngredientCategory { get; set; }
        #endregion
      }
    }
