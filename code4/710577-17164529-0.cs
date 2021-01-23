    public class Pizza { }
    public class Omlette { }
    public class Recipe<T> : IRecipe<T> where T : class, new()
    {
        private readonly IEnumerable<IIngredient<T>> _ingredients;
        public Recipe(IEnumerable<IIngredient<T>> ingredients)
        {
            _ingredients = ingredients;
        }
        public ICollection<IIngredient<T>> Ingredients 
        { 
            get {  return _ingredients.ToList(); } 
        }
        public T Cook()
        {
            return new T();
        }
    }
    
    public interface IRecipe<T>
    {
        ICollection<IIngredient<T>> Ingredients { get; }
        T Cook();
    }
    public interface IIngredient<T> { }
    public class Cheese : IIngredient<Pizza>, IIngredient<Omlette> { }
    public class Tomato : IIngredient<Pizza>, IIngredient<Omlette> { }
    public class Egg : IIngredient<Omlette> { }
