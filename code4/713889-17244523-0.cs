    public Cat Fix(Cat cat, dynamic properties) { ... }
    cats.Add(Fix(new Cat("happy"), new { Mean=false }));
    // extension method:
    public static class CatExtensions {
         public static Cat Fix(this Cat cat, dynamic properties) { ... }
    }
    cats.Add(new Cat("happy").Fix(new { Mean=false }));
