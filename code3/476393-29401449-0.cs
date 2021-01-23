    // does not compile
    ISomeInterface {
       static void DoSomething();
       static bool TestSomething(string pValue);
       // etc... 
    }
    static class SomeStaticClass : ISomeInterface {
       public static void DoSomething() {
       }
       public static bool TestSomething(string pValue) {
       }
    }
