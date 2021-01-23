        public Stock()
        {
            Name = "Erin";
        }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.ArrayList fruits = new System.Collections.ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");
            fruits.Add(new Stock());
            // Apply OfType() to the ArrayList.
            var query1 = fruits.OfType<Stock>();
            Console.WriteLine("Elements of type 'stock' are:");
            foreach (var fruit in query1)
            {
                Console.WriteLine(fruit);
            }
            
        }
    }
