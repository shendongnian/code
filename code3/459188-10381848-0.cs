    namespace ConsoleApplication12
    {
        using System;
        using System.Diagnostics;
        class Foo
        {
            public Foo() {
            }
            public event EventHandler Load;
            protected virtual void OnLoad() {
                EventHandler handler = Load;
                if (handler != null) {
                    handler(this, new EventArgs());
                }
                Debug.WriteLine("Invoked Foo.OnLoad");
            }
            public void Run() {
                OnLoad();
            }
        }
        class DerivedFoo : Foo
        {
            protected override void OnLoad() {
                base.OnLoad();
                Debug.WriteLine("Invoked DerivedFoo.OnLoad");
            }
        }
        class Program
        {
            static void Main(string[] args) {
                DerivedFoo dFoo = new DerivedFoo();
            
                dFoo.Load += (sender, e) => {
                    Debug.WriteLine("Invoked dFoo.Load subscription");    
                };
                dFoo.Run();
            }
        }
    }
