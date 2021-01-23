    public class Foo
    {
        // provide default value (or inject it via ctor)
        private Parent _parent = new Child1(); 
    
        public void ChangeChild(Parent parent){
            _parent = parent;
        }
    
        public void Bar()
        {
            _parent.DoSomething();  
        }
    }
    
    public abstract class Parent
    {
        public abstract void DoSomething();
    }
    
    public class Child1: Parent
    {
        public override void DoSomething() { ... }
    }
    
    public class Child2: Parent
    {
        public override void DoSomething() { ... }
    }
