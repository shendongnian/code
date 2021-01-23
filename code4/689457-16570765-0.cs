    public class WithComplexDependency
    {
       public void DoSomething()
       {
         // Extract original code into a virtual protected method
         // dependency.MethodThatWillBreak();
         CallMethodThatWillBreak();
       }
      
       virtual protected void CallMethodThatWillBreak()
       {
          dependency.MethodThatWillBreak();
       }
    }
