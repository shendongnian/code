    interface I1 { }
    interface I2 { }
    class C : I1, I2 { }
    static class Ex1 {
      public static void M(this I1 self) { }
    }
    static class Ex2 {
      public static void M(this I2 self) { }
    }
    ...
    new C().M(); // ERROR: The call is ambiguous
