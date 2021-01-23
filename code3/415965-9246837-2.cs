    class ItemConverter : CustomCreationConverter<Item> {
            readonly IEnumerable<Category> _repository;
    
            public ItemConverter(IEnumerable<Category> categories)
            {
                    _repository = categories;
            }
    
            public override Item Create(Type objectType)
            {
                    return new Item();
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                    JObject jObject = JObject.Load(reader);
                    int categoryId = jObject["categoryId"].ToObject<int>();
                    Category category = _repository.Where(x => x.CategoryId == categoryId).SingleOrDefault();
    
                    Item result = (Item)base.ReadJson(jObject.CreateReader(), objectType, existingValue, serializer);
                    result.Category = category;
    
                    return result;
            }
    }
    
    class Item {
            [JsonProperty("name")]
            public string Name { get; set; }
            public Category Category { get; set; }
            // other properties.
    }
    
    class Category {
            [JsonProperty("id")]
            public int CategoryId { get; set; }
    
            [JsonProperty("name")]
            public string Name { get; set; }
            // other properties.
    }
    
    class Program {
            static void Main(string[] args)
            {
                    // sample : json contains items and/or categories in an array.
                    string jsonString = @"
                    [ 
                            {
                                            ""id"" : ""2"",
                                    ""categoryId"" : ""35"",
                                          ""type"" : ""item"",
                                          ""name"" : ""hamburger""
                            },
                            {
                                            ""id"" : ""35"",
                                          ""type"" : ""category"",
                                          ""name"" : ""drinks"" 
                            }
                    ]";
    
                    JArray jsonArray = JArray.Parse(jsonString);
    
                    // Separate between category and item data.
                    IEnumerable<JToken> jsonCategories = jsonArray.Where(x => x["type"].ToObject<string>() == "category");
                    IEnumerable<JToken> jsonItems = jsonArray.Where(x => x["type"].ToObject<string>() == "item");
    
                    // Create list of category from jsonCategories.
                    IEnumerable<Category> categories = jsonCategories.Select(x => x.ToObject<Category>());
    
                    // Settings for jsonItems deserialization.
                    JsonSerializerSettings itemDeserializerSettings = new JsonSerializerSettings();
                    itemDeserializerSettings.Converters.Add(new ItemConverter(categories));
                    JsonSerializer itemDeserializer = JsonSerializer.Create(itemDeserializerSettings);
    
                    // Create list of item from jsonItems.
                    IEnumerable<Item> items = jsonItems.Select(x => x.ToObject<Item>(itemDeserializer));
            }
    }
