    class Program
    {
        static void Main(string[] args)
        {
            FoodProducts FoodProd1 = new FoodProducts("FP001", "Meat", 15.99, 200, 100, "Australia");
            FoodProducts FoodProd2 = new FoodProducts("FP002", "Bread", 2.99, 150, 50, "Italy");
            FoodProd1.Print();
            FoodProd2.Print();
            Console.ReadLine();
        }
    }
    public class Products 
    { 
        string id; 
        string name; 
        double price; 
        int soldCount; 
        int stockCount; 
 
        public Products(string id, string name, double price,  
                          int soldCount, int stockCount) 
        { 
            this.id = id; 
            this.name = name; 
            this.price = price; 
            this.soldCount = soldCount; 
            this.stockCount = stockCount; 
        }
        public virtual void Print()
        {
            Console.WriteLine("Product ID: {0}", this.id);
            Console.WriteLine("Product Name: {0}", this.name);
            Console.WriteLine("Prodcut Price: {0}", this.price);
            Console.WriteLine("Sold Counter: {0}", this.soldCount);
            Console.WriteLine("Stock Count: {0}", this.stockCount);
            Console.WriteLine();
        } 
    }
    class FoodProducts : Products
    {
        private string origin;
        public FoodProducts(string id, string name, double price, int soldCount, int stockCount, string origin)
            : base(id, name, price, soldCount, stockCount)
        {
            this.origin = origin;
        }
        private string Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Origin: {0}", this.Origin);
        }
    }
