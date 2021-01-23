    public static Expression<Func<Animal, IEnumerable<Food>>> GetAllowedFoods(MyDataContext db) {
      var isAllowed = IsAllowedDiet();
      return a => db.Foods.AsExpandable().Where(f => isAllowed.Invoke(a, f));
    }
    public static Expression<Func<Food, IEnumerable<Animal>>> GetAllowedAnimals(MyDataContext db) {
      var isAllowed = IsAllowedDiet();
      return f => db.Animals.AsExpandable().Where(a => isAllowed.Invoke(a, f));
    }
