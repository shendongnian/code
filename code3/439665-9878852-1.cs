    public class MyEventArgs : EventArgs
    {
    }
    public class EventContainer
    {
        public event EventHandler<MyEventArgs> MyEvent;
        public void Fire()
        {
            Console.WriteLine("Firing");
            if (MyEvent != null)
            {
                MyEvent(this, new MyEventArgs());
            }
            Console.WriteLine("Fired");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EventContainer container = new EventContainer();
            var adder = container.GetType().GetMethod("add_MyEvent");
            var remover = container.GetType().GetMethod("remove_MyEvent");
            object self = null;
            Func<object> getSelf = () => self;
            var block = Expression.Block(
                // Call something to output to console.
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                    Expression.Constant("Event called")),
                // Now call the remove_Event method.
                Expression.Call(
                    Expression.Constant(container), // passing the container as "this"
                    remover, // And the remover as the method info
                    Expression.Convert( // we need to cast the result of getSelf to the correct type to pass as an argument
                        Expression.Invoke( // For the parameter (what to convert), we need to call getSelf
                            Expression.Constant(getSelf)), // So this is a ref to getSelf
                        adder.GetParameters()[0].ParameterType) // finally, say what to convert to.
                   ) 
               );
            // Create a lambda of the correct type.
            var lambda = Expression.Lambda(
                adder.GetParameters()[0].ParameterType, 
                block, 
                Expression.Parameter(typeof(object)), 
                Expression.Parameter(typeof(MyEventArgs)));
            var del = lambda.Compile();
            // Make sure "self" knows what the delegate is (so our generated code can remove it)
            self = del;
            // Add the event.
            adder.Invoke(container, new object[] { del });
            // Fire once - see that delegate is being called.
            container.Fire();
            // Fire twice - see that the delegate was removed.
            container.Fire();
        }
    }
