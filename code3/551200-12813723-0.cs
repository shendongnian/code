    public abstract class TemplateMethod
    {
        internal void DoSomething() { ... }
    }
    public abstract class Consumer
    {
        TemplateMethod _Template = ...;
        protected void DoSomething()
        {
            _Template.DoSomething();
        }
    }
