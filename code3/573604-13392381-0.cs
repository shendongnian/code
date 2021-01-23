    enum PizzaSize
    {
        Small,
        Medium,
        Large,
        XLarge
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pizzas = new[] {
                new {
                    Name = "Plain",
                    Prices = new [] {
                        new { Size = PizzaSize.Small, Price = 8.80M },
                        new { Size = PizzaSize.Medium, Price = 12.80M },
                        new { Size = PizzaSize.Large, Price = 16.80M },
                        new { Size = PizzaSize.XLarge, Price = 20.80M },
                    }.ToDictionary(item => item.Size, item => item.Price)
                },
                new {
                    Name = "Hawaian",
                    Prices = new [] {
                        new { Size = PizzaSize.Small, Price = 10.90M },
                        new { Size = PizzaSize.Medium, Price = 15.90M },
                        new { Size = PizzaSize.Large, Price = 20.90M },
                        new { Size = PizzaSize.XLarge, Price = 25.90M },
                    }.ToDictionary(item => item.Size, item => item.Price)
                },
                new {
                    Name = "Beefy",
                    Prices = new [] {
                        new { Size = PizzaSize.Small, Price = 10.90M },
                        new { Size = PizzaSize.Medium, Price = 16.90M },
                        new { Size = PizzaSize.Large, Price = 21.90M },
                        new { Size = PizzaSize.XLarge, Price = 26.90M },
                    }.ToDictionary(item => item.Size, item => item.Price)
                },
                new {
                    Name = "Vegetarian",
                    Prices = new [] {
                        new { Size = PizzaSize.Small, Price = 10.90M },
                        new { Size = PizzaSize.Medium, Price = 14.90M },
                        new { Size = PizzaSize.Large, Price = 19.90M },
                        new { Size = PizzaSize.XLarge, Price = 24.90M },
                    }.ToDictionary(item => item.Size, item => item.Price)
                },
            };
            int maxNameWidth = pizzas.Max(item => item.Name.Length);
            const string nameOfPizzaLabel = "Name of Pizza";
            if (maxNameWidth < nameOfPizzaLabel.Length)
            {
                maxNameWidth = nameOfPizzaLabel.Length;
            }
            Console.WriteLine("what type of Pizza do you want?");
            Console.WriteLine("{0} \t{1}\t{2}\t{3}\t{4}",
                nameOfPizzaLabel.PadLeft(maxNameWidth),
                PizzaSize.Small,
                PizzaSize.Medium,
                PizzaSize.Large,
                PizzaSize.XLarge);
            foreach (var pizza in pizzas)
            {
                Console.WriteLine("{0}:\t{1:C}\t{2:C}\t{3:C}\t{4:C}",
                    pizza.Name.PadLeft(maxNameWidth),
                    pizza.Prices[PizzaSize.Small],
                    pizza.Prices[PizzaSize.Medium],
                    pizza.Prices[PizzaSize.Large],
                    pizza.Prices[PizzaSize.XLarge]);
            }
        }
    }
