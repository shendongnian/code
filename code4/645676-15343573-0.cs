    public abstract class MyBase : IInterface {
        public virtual IEnumerable<object> DoSomething() {
           // blah
        }
    }
    
    public class MyClass : MyBase {
        public override IEnumerable<object> DoSomething() {
            // blah
        }
    }
