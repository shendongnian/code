    class Fruit { }
    class Banana : Fruit{}
    class Apple : Fruit{}
    static void Main(string[] args)
    {
        var fruits = new List<Fruit> { new Banana(),  new Banana(), new Apple(), new Fruit() };
        int bananas = fruits.OfType<Banana>().Count(); // 2
        int apples = fruits.OfType<Apple>().Count(); // 1
        int fruitc = fruits.OfType<Fruit>().Count(); // 4
        int exactFruits = GetOfExactType<Fruit,Fruit>(fruits).Count();  // 1
    }
    static IEnumerable<V> GetOfExactType<T, V>(IEnumerable<T> coll)
    {
        foreach (var x in coll)
        {
            if (x.GetType().TypeHandle.Value == typeof(V).TypeHandle.Value)
            {
                yield return (V)(object)x;
            }
        }
    }
