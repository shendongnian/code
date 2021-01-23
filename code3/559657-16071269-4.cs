Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(2008, 12, 28);
product.Price = 3.99M;
product.Sizes = new string[] { "Small", "Medium", "Large" };
 
string json = JsonConvert.SerializeObject(product);
//{
//  "Name": "Apple",
//  "Expiry": "2008-12-28T00:00:00",
//  "Price": 3.99,
//  "Sizes": [
//    "Small",
//    "Medium",
//    "Large"
//  ]
//}
 
Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
