    public abstract class BaseClass
    {
       public void TemplateMethod()
       {
          DoSomething();
          DoSomethingElse();
       }
       protected virtual void DoSomething()
       {
          // implementation that can be changed or extended
       }
       // no implementation; an implementation must be provided in the inheritor
       protected abstract void DoSomethingElse();
    }
    public sealed class SubClass : BaseClass
    {
       protected override DoSomething()
       {
          // add extra implementation before
          base.DoSomething(); // optionally use base class' implementation
          // add extra implementation after
       }
       protected override DoSomethingElse()
       {
          // write an implementation, since one did not exist in the base
       }
    }
