    //your object
    Product product = new Product();
    product.Name = "Apple";
    product.Expiry = new DateTime(2008, 12, 28);
    product.Price = 3.99M;
    product.Sizes = new string[] { "Small", "Medium", "Large" };
    
    //serialize it 
    string json = JsonConvert.SerializeObject(product);
    //will look like this :
    //{
    //  "Name": "Apple",
    //  "Expiry": new Date(1230422400000),
    //  "Price": 3.99,
    //  "Sizes": [
    //    "Small",
    //    "Medium",
    //    "Large"
    //  ]
    //}
     
    //on the 'other end' you just deserialize it with one line of code!
    Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
