    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
    
        public class Product
        {
            public string description;
            public double price;
            //normally you want to use eitehr an int for price(representing cents) or a decimal type, instead of double
            //just using a double here for the sack of simplicity
            // you'll also want to use properties instead of variable fields, but i'm using variable fields for simplicity
    
            // constructor
            public Product(string description, double price)
            {
                this.description = description;
                this.price = price;
            }
    
            public string GetDetailLine()
            {
                // google "String.Format" for more information,
                // basically it replaces things in the {0} and {1}, with the other parameters
                // the ":c" in {1:c} part means format as currency
                return String.Format("You ordered {0}.  It costs: {1:c}", description, price);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Product> products = new List<Product>();
    
    
                Console.Write("Do You Want a Soda?   ");
                string input = Console.ReadLine();
                //the .ToUpper() part makes it upper case
                if (input.ToUpper() == "YES")
                {
                    Product soda = new Product("soda", 2.50);
                    products.Add(soda);
                }
    
                double total = 0; 
                for(int i = 0; i<products.Count; i++)
                {
                    Console.WriteLine(products[i].GetDetailLine());
                    total += products[i].price;
                }
    
                //you can also use Console.Writeline like String.Format
                Console.WriteLine("Your Total is:  {0:c}", total);
    
    
                // this is just to pause in-case you're debugging from visual studio
                Console.ReadLine();
            }
        }
    }
