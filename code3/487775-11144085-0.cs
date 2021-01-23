    interface IFruit
    {
        string Name { get; }
        string SerialNumber { get; }
    }
    class Apple : IFruit
    {
        private string _serial = Guid.NewGuid().ToString();
        public string Name {
            get {
                return "Apple";
            }
        }
        public string SerialNumber {
            get { return _serial; }
        }
    }
    class AppleBasket : IEnumerable<IFruit>
    {
        private List<Apple> _items = new List<Apple>();
        public void Add(Apple apple) {
            _items.Add(apple);
        }
        public IEnumerator<IFruit> GetEnumerator() {
            return _items.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }
    }
    /******************/
    
    AppleBasket basket = new AppleBasket();
    Apple apple1 = new Apple();
    basket.Add(apple1);
    Apple apple2 = new Apple();
    basket.Add(apple2);
    foreach (IFruit fruit in basket) {
        Console.WriteLine(fruit.SerialNumber);
    }
    
