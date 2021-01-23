    public class Fruit {}
    public class Apple : Fruit 
    {
      public void M(Animal a) {}
      private class MagicApple : Apple 
      {
        public void M(Giraffe g) {}
      }
      public static Apple MakeMagicApple() { return new MagicApple(); }
    }
    ...
    dynamic d1 = Apple.MakeMagicApple();
    dynamic d2 = new Giraffe();
    d1.M(d2);
