    public Cat Fix<T>(Cat cat, T properties) { ... }
    cats.Add(Fix(new Cat("happy"), new { Mean=false }));
    // extension method:
    public static class CatExtensions {
         public static Cat Fix<T>(this Cat cat, T properties) { ... }
    }
    cats.Add(new Cat("happy").Fix(new { Mean=false }));
