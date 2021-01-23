    public class Product
    {
        public int id;
        public int catId;
        public int manId;
        public string name;
    }
    
    public class Man
    {
        public int id;
        public string name;
    }
    
    public class Cat
    {
        public int id;
        public string name;
    }
    
    public class Projection
    {
        public Cat cat;
        public Man man;
        public Product p;
    }
    
    
    [Fact]
    public void Do()
    {
        var products = new List<Product>()
           {
               new Product{id=1, catId=1, manId=1, name="1"},
               new Product{id=2, catId=1, manId=1, name="2"},
               new Product{id=3, catId=1, manId=2, name="3"},
               new Product{id=4, catId=2, manId=1, name="4"},
               new Product{id=5, catId=2, manId=3, name="5"},
           };
    
        var cats = new List<Cat>()
           {
               new Cat() {id = 1, name = "1c"},
               new Cat() {id = 2, name = "2c"}
           };
    
        var mans = new List<Man>()
           {
               new Man() {id = 1, name = "1m"},
               new Man() {id = 2, name = "2m"},
               new Man() {id = 3, name = "3m"}
           };
    
        var results = products
            .Join(cats, x => x.catId, x => x.id, (x, y) => new Projection(){cat = y, p = x})
            .Join(mans, x => x.p.manId, x => x.id, (x, y) => { x.man = y; return x; })
            ;
        
        foreach (var x in results)
        {
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", x.cat.id, x.cat.name, x.man.id, x.man.name, x.p.id, x.p.name);
        }
    }
