    public class MyItem
    {
        private readonly string name;
        public string Name
        {
            get { return this.name; }
        }
        
        private readonly decimal price;
        public decimal Price
        {
            get { return this.price; }
        }
        
        public MyItem(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        
        public override string ToString()
        {
            return this.name;
        }
    }
