    partial class A {
      public static A Instance = CreateInstance();
      public int a = 3;
      public int b = Instance.a;
    }
 
