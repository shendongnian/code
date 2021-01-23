    public static class AnimalFactory
    {
      public static Dog GetDog()
      {
        return new Dog();
      }
      
      public static Cat GetCat()
      {
        return new Cat();
      }
    }
