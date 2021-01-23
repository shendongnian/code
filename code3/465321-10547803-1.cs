    class Program {
            static void Main(string[] args) {
                Func<int> i = () => 10;
                var a1 = new ClassA(i);
    
                Func<string> s = () => "Hi there";
                var a2 = new ClassA(s);            
            }
        }
    
        internal class ClassA {
            private readonly Delegate _delegate;
    
            public ClassA(Delegate func) { // just pass in a delegate instead of Func<T>
                _delegate = func;
            }
        }
