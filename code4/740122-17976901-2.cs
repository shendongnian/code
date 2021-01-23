    public static class A {
        public static void F() { ... }
    }
    public static class B {
        public static void F() { ... }
    }
    
    List<Type> typeList = new List<Type> { typeof(A), typeof(B) };
    foreach(var type in typeList)
    {
        type.GetMethod("F").Invoke(null, null); 
    }
