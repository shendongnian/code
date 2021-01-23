    public class RecipeViewModel()
    {
        public RecipeViewModel()
        {
            Recipe = new Recipe();
        }
        public Recipe Recipe { get; set; }
        public string TagList { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
