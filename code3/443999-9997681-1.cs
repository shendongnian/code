    interface I1 { }
    interface I2 { }
    class C : I1, I2 { }
    static class Ex {
      public static void M(this I1 self) { }
      public static void M(this I2 self) { }
    }
    ...
    new C().M(); // ERROR: The call is ambiguous
