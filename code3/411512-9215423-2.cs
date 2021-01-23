    public FruitCollection<T, U> : FruitCollection<T>
        where T : U
        where U : Fruit
    {
        private FruitCollection<U> baseCollection;
        
        public FruitCollection(FruitCollection<U> baseCollection)
            : base()
        {
            this.baseCollection = baseCollection;
            // here I added code that throws events whenever the collection is changed
            // I used those events to add/remove fruit to the base collection, and vice versa
            // see the link below.
            ...
        }
        
        ...
    }
    
    public class GenericTree<T>: Tree
        where T : Fruit
    {
        private FruitCollection<T> fruits;
        
        // use the new keyword to hide the base collection
        new public FruiCollection<T> Fruits
        {
            get { return fruits; }
        }
        
        public GenericTree()
            : base()
        {
            // after hiding the base collection, use base.Fruits to get it
            fruits = new FruitCollection<T, Fruit>(base.Fruits);
        }
    }
