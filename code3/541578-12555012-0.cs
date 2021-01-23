    var productsJObject = JObject.Parse(result.Content.ReadAsStringAsync().Result);
    
    foreach (var category in categories)
    {
        foreach (var category2 in category.Value)
        {
            foreach (var category3 in category2.Value)
            {
                var olist = new MyList { Id = version.SelectToken("id").ToString()
                          };
            }
        }
    }
