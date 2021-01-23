    using System;
    
    class Program {
        delegate void foo(long arg);
        static void Main(string[] args) {
            var obj = new Example();
            var dlg = Delegate.CreateDelegate(typeof(foo), obj, "Target");
            dlg.DynamicInvoke(42);
        }
    }
    
    class Example {
        private long field;
        public void Target(long arg) {
            field = arg;
        }
    }
