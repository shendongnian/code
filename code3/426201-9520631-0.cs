    // Base assembly; does not reference System.Web
    public class HelperBase
    {
        public virtual void DoSomething() { ... }
        public virtual void DoSomethingElse() { ... }
    }
    
    public static class StaticHelper
    {
        public static HelperBase Helper { get; set; }
        static void DoSomething()
        {
            Helper.DoSomething();
        }
    
        static void DoSomethingElse()
        {
            Helper.DoSomethingElse();
        }
    }
    
    // HelperWeb assembly; references System.Web, base assembly
    public class HelperWeb : HelperBase
    {
        // override base implementation, using System.Web
        public virtual void DoSomethingElse() { ... }
    }
    
    
    // usage at top level:
    
    StaticHelper.Helper = new HelperBase();
    // or
    StaticHelper.Helper = new HelperWeb();
    StaticHelper.DoSomething();
