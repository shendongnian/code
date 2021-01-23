    public static class IngredientExtensions
    {
        public static int GetSortNumber(this Ingredient item) {
           return item.Name == "Protein" ? 1 :
              item.Name == "oil" ? 2 :
              item.Name == "Fibre" ? 3 : 
              item.Name == "Ash" ? 4 : 
              5;
        }
    }
    ...
    frmltnIngredientsList.OrderBy(item => item.GetSortNumber());
