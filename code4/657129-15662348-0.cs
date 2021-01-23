    public abstract class Thing
    {
      private Thing() {}
      private RedThing : Thing { ... }
      public static Thing GetRedThing() { return new RedThing(); }
    }
