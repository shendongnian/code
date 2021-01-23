    class ItemConverter : CustomCreationConverter<Item> {
            public override Item Create(Type objectType)
            {
                    return new Item();
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                    JObject jObject = JObject.Load(reader);
                    int categoryId = jObject["categoryId"].ToObject<int>();
                    Category category = Program.Repository.GetCategoryById(categoryId);
                            
                    Item result = (Item)base.ReadJson(jObject.CreateReader(), objectType, existingValue, serializer);
                    result.Category = category;
    
                    return result;
            }
    }
    
    class Item {
            [JsonProperty("itemName")]
            public string ItemName { get; set; }
            public Category Category { get; set; }
            // other properties.
    }
    
    class Category {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            // other properties.
    }
    
    class MockCategoryRepository {
            IList<Category> _repository;
    
            public MockCategoryRepository()
            {
                    _repository = new List<Category>();
                    _repository.Add(new Category() { CategoryId = 1, Name = "Drink" });
                    _repository.Add(new Category() { CategoryId = 35, Name = "Food" });
                    _repository.Add(new Category() { CategoryId = 70, Name = "Fruit" });
            }
    
            public Category GetCategoryById(int id)
            {
                    return _repository.Where(x => x.CategoryId == id).SingleOrDefault();
            }
    }
    
    class Program {
            public static MockCategoryRepository Repository { get; private set; }
    
            static void Main(string[] args)
            {
                    Repository = new MockCategoryRepository(); // initialize mock repository
    
                    // sample : json contains two items in an array.
                    string jsonString = @"
                    [ 
                            { ""categoryId"":""35"", ""itemName"":""Item A"" },
                            { ""categoryId"":""70"", ""itemName"":""Item B"" },
                    ]";
    
                    List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString, new ItemConverter());
            }
    }
