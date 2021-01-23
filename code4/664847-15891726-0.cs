    public class SomeBaseClassInSomeBinary
    {
       protected virtual void Method1(...) {}
       protected virtual void WriteFeed (...) {}
    } 
    public class SomeClassInSomeBinary: SomeBaseClassInSomeBinary
    {
       protected override void Method1(...) { base.Method1(...); }
       protected override void WriteFeed (...) { base.WriteFeed (...); }
    } 
    // **** your code
    public class MyCode: SomeBaseClassInSomeBinary
    {
         private SomeClassInSomeBinary Composite = new SomeClassInSomeBinary();
         protected override void Method1(...) { Composite.Method1(...); }
         protected override void WriteFeed (...) { your implementation }
    }
