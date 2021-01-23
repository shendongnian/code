    class Vegetable
    {
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
    class Recipe
    {
        public Recipe(string name, string path)
        {
           Name = name;     Path = path;
        }
        public string Name { get; set; }
        public string Path { get; set; } 
    }
    vegiesList.ForEach(veg => comboBox1.Items.Add(veg.Name));
    //You can select its property here depending on what property you want to add on your `ComboBox`
