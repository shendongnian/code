    using System.Diagnostics;
    ...
        public partial class App : Application {
            public App() {
                if (Debugger.IsAttached) {
                    var def = Debug.Listeners["Default"];
                    Debug.Listeners.Remove(def);
                    Debug.Listeners.Add(new MyListener(def));
                }
            }
            private class MyListener : TraceListener {
                private TraceListener defListener;
                public MyListener(TraceListener def) { defListener = def; }
                public override void Write(string message) { defListener.Write(message); }
                public override void WriteLine(string message) { defListener.WriteLine(message); }
                public override void Fail(string message, string detailMessage) {
                    base.Fail(message, detailMessage);
                    Debugger.Break();
                }
            }
        }
