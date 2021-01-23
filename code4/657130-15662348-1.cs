    public abstract class Thing
    {
      private Thing() {}
      private class RedThing : Thing { ... }
      public static Thing GetRedThing() { return new RedThing(); }
    }
