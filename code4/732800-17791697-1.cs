     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var Categories = new List<Category>() { new Category { CategoryName = "CatName", Products = new List<Product>() { new Product { Name = "ProductName1" } } } };
            Func<Product, string> selector = p => p.Name;
            var sb = new StringBuilder();
            var query = Categories.Select(c => new
            {
                Products = c.Products.OrderBy(selector)
            });
            foreach (var x in query)
            {
                sb.AppendLine(x.Products.First().Name);
            }
            Console.WriteLine(sb.ToString());
            Console.Read();
        }
        public class Product
        {
            public string Name { get; set; }
        }
        public class Category
        {
            public string CategoryName { get; set; }
            public List<Product> Products { get; set; }
        }
    }
}
