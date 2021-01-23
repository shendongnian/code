    public static void CollectionsExtensions
    {
          public static void RemoveInvalidItems(this ICollection<MyClass> some)
          {
                 foreach(MyClass item in some.ToList())
                 {
                        if(!new Validator().ValidateObject(item)) // Your class having your validation method
                        {
                              some.Remove(item);
                        }
                 }
           }
    }
