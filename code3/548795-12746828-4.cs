      public class Zoo<T> where T : IZooAnimal
      {
        public List<Type> AnimalTypes = new List<Type>();
        public void AddType(Type a)
        {
          if (typeof(T) == a)
            AnimalTypes.Add(a);
        }
      }
