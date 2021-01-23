    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Ingredient : Item
    {
        public double Price { get; set; }
    }
    public class Recipe : Item
    {
        public List<RecipeItem> RecipeItems { get; set; }
    }
    public class RecipeItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public double Quantity { get; set; }
    }
