    using System;
    using System.Collections.Generic;
    using SimpleLib;  //That is the VB assembly
    
    namespace ConsoleApplication1
    {
        public class ProductsViewModel : List<ProductViewModel>
        {
    
        }
    
        public class ProductViewModel
        {
            public SizeViewModel[] ItemizedSize { get; set; }
        }
    
        public class SizeViewModel
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
    
            public override string ToString()
            {
                return this.Name + " " + this.Quantity.ToString();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                AutoMapper.Mapper.CreateMap<Size, SizeViewModel>();
                AutoMapper.Mapper.CreateMap<Product, ProductViewModel>();
    
                List<Product> productDetails = new List<Product>()
                                                   {
                                                       new Product() {itemizedSize = new Size[1] {new Size("hello", 2, 5)}},
                                                       new Product() {itemizedSize = new Size[1] {new Size("hello2", 4, 10)}}
                                                   };
    
                ProductsViewModel model = AutoMapper.Mapper.Map<List<Product>, ProductsViewModel>(productDetails);
                AutoMapper.Mapper.AssertConfigurationIsValid();
    
                Console.WriteLine("Count: {0}", model.Count);
                Console.WriteLine("First Product: {0}", model[0].ItemizedSize[0].ToString());
                Console.WriteLine("Second Product: {0}", model[1].ItemizedSize[0].ToString());
    
                Console.ReadLine();
            }
        }
    }
