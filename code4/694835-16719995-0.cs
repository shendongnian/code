    public static class AnotherClass
    {
      public static void GiveFood(Cat cat) {}
      public static void GiveFood(Dog dog) {}
      public static void GiveFood(Mammal mammal)
      {
        throw new AnimalNotRecognizedException("I don't know how to feed a " + mammal.GetType().Name + ".");
      }
    }
