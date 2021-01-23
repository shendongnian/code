    interface ITracer {
        void Trace(string s);
    }
    class TracerA : ITracer {
        public void Trace(string s) {
            // ...
        }
    }
    class TracerB : ITracer {
        public void Trace(string s) {
            // ...
        }
    }
    class TracerFactory {
        public static ITracer Make(string name) {
            if (name.Equals("A")) return new TracerA();
            if (name.Equals("B")) return new TracerB();
            throw new ApplicationException("Unknown: "+name);
        }
    }
