    public class Recipe
    {
        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public Recipe() { }
        public Recipe(string _recipeName, string _IngredientName)
        {
            RecipeName = _recipeName;
            IngredientName = _IngredientName;
        }
    }
    public class RecipeGroup
    {
        public string RecipeName{get;set;}
        public List<Recipe> Recipe{get;set;}
    }
    public class RecipeGroupDictionary
    {
        private Dictionary<string, List<Recipe>> data;
        public RecipeGroupDictionary()
        {
            data = new Dictionary<string, List<Recipe>>();
        }
        public bool add(Recipe vr)
        {
            this[vr.RecipeName].Add(vr);
            return true;
        }
        public List<Recipe> this[string key]
        {
            get
            {
                if (!data.ContainsKey(key))
                    data[key] = new List<Recipe>();
                return data[key];
            }
            set
            {
                data[key] = value;
            }
        }
        public ICollection<string> Keys
        {
            get
            {
                return data.Keys;
            }
        }
        public List<RecipeGroup> getRecipeGroup()
        {
            var result = new List<RecipeGroup>();
            foreach (var key in data.Keys)
            {
                result.Add(new RecipeGroup { RecipeName = key, Recipe = data[key] });
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new List<Recipe>();
            var recipeGroup = new RecipeGroupDictionary();
            arr.Add(new Recipe{ RecipeName="1", IngredientName="A"});
            arr.Add(new Recipe{ RecipeName="1", IngredientName="B"});
            arr.Add(new Recipe{ RecipeName="1", IngredientName="C"});
            arr.Add(new Recipe { RecipeName = "2", IngredientName = "B" });
            arr.Add(new Recipe { RecipeName = "2", IngredientName = "C" });
            arr.Add(new Recipe { RecipeName = "3", IngredientName = "A" });
            arr.Add(new Recipe { RecipeName = "3", IngredientName = "X" });
            arr.Add(new Recipe { RecipeName = "3", IngredientName = "Y" });
            var rnset = from row in arr
                        where row.IngredientName == "A"
                        select row.RecipeName;
            var result = (from row in arr
                          where rnset.Contains(row.RecipeName) && recipeGroup.add(row) //Won't be executed if the first condition is false.
                          select row ).ToArray(); //To array is List<Recipe>, if you don't want recipe group you can remove all the recipe dictionary related.
            foreach (var key in recipeGroup.Keys)
            {
                foreach(var recipe in recipeGroup[key])
                    Console.WriteLine("RN:{0}, IA:{1}", recipe.RecipeName, recipe.IngredientName);
            }                      
        }
    }
