    public class Recipe
    {
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<IFood> Foods{ get; set; }
        ...
    }
