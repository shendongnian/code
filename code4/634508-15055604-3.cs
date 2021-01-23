    public static class Foo {
      public static void MySleep(int milliseconds) {
        int startTick = Environment.TickCount;
        while (Environment.TickCount - startTick < milliseconds)
          Application.DoEvents();
      }
    }
