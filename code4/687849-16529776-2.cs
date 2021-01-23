    public class Recipe
    {
        string _oveskrift;
        int _recipe_id;
        string _opskrift;
        int _kcal;
        public string Oveskrift
        {
            get
            {
                return _oveskrift;
            }
            private set
            {
                _oveskrift=value;
            }
        }
        public int RecipeId
        {
            get
            {
                return _recipe_id;
            }
            private set
            {
                _recipe_id = value;
            }
        }
        public string Opskrift
        {
            get
            {
                return _opskrift;
            }
            private set
            {
                _opskrift = value;
            }
        }
        public int Kcal
        {
            get
            {
                return _kcal;
            }
            private set
            {
                _kcal = value;
            }
        }
        public Recipe(string overskrift, int recipe_id, string opskrift, int kcal)
        {
            _oveskrift = overskrift;
            _recipe_id = recipe_id;
            _opskrift = opskrift;
            _kcal = kcal;
        }
    }
