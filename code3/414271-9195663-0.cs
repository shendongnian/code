    public interface IFoo {
        String Bar { get; set; }
    }
    public class ImplicitFoo : IFoo {
        public string Bar {get;set;}
    }
    public class ExplicitFoo : IFoo {
        private String _Bar;
        string IFoo.Bar {
            get {
                return _Bar;
            }
            set {
                _Bar = value;
            }
        }
    }
    public class Test {
        public void Test() {
            var iml = new ImplicitFoo();
            // Works fine
            Console.WriteLine(iml.Bar);
            var expl = new ExplicitFoo();
            var fooInterface = (IFoo)expl;
            // Works fine
            Console.WriteLine(fooInterface.Bar);
            // Throws compile time exception
            Console.WriteLine(expl.Bar);
        }
    }
