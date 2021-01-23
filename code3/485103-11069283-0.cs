    namespace HelloWebAPI.Models 
    { 
        public class Product 
        { 
            public int Id { get; set; } 
            public string Name { get; set; } 
            public string Category { get; set; } 
            public decimal Price { get; set; } 
        } 
    }
    
    namespace MyClient
    {
        public partial class MainPage
        {
            //...
            public async void Button_Click(object sender, RoutedEventArgs e)
            {
                var c = new HttpClient();
                var resp = await c.GetAsync("http://localhost:xxxx/api/products");
                var prod = await resp.Content.ReadAsAsync<Product>();
                // ...
            }
        }
    }
