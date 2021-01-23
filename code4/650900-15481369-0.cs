    public class SomeController
    {
        public SomeController() : this( new SomeObj(new configuration(), new SomethingElse(new SomethingElseToo())) ) 
        {
        }
    
        publiv SomeController(SomeObj obj)
        {
            this.obj = obj;
        }
    }
