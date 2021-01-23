    void Main()
    {
    	var foo = new Foo();
        foo.Bar += (s, e) => {
            Console.WriteLine("Executed");
            
            var self = new StackFrame().GetMethod();
            var eventField = foo.GetType()
                                .GetField("Bar", BindingFlags.NonPublic | 
                                                 BindingFlags.Instance);
            if(eventField == null)
                return;
            var eventValue = eventField.GetValue(foo) as EventHandler;
            if(eventValue == null)
                return;
            var eventHandler = eventValue.GetInvocationList()
                                         .OfType<EventHandler>()
                                         .FirstOrDefault(x => x.Method == self)
                                   as EventHandler;
            if(eventHandler != null)
                foo.Bar -= eventHandler;
        };
        
        foo.RaiseBar();
        foo.RaiseBar();
    }
    
    public class Foo
    {
        public event EventHandler Bar;
        public void RaiseBar()
        { 
            var handler = Bar;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
    }
