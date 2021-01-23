    //nonsense class
    public class Foo {
        public string Bar { get; set; }
    }
    
    //nonsense event.
    public event Func<Foo, bool> SomeEvent;
    
    void BindAndFire() {
        //wire it up.
        SomeEvent += (foo) => { 
            var a = DateTime.Now.Millisecond % 2;
            foo.Bar = (a == 0) ? "Hooray" : "Boo";
            return true;
        };
        SomeEvent += (foo) => { 
            return foo.Bar != "Boo";
        };
        SomeEvent += (foo) => { 
            foo.Bar += ", you made it!";
            return true;
        };
    
        //fire the event.
        var f = new Foo();
        foreach(var s in SomeEvent.GetInvocationList()) {
            if(!s(f)) break;
        }
    }
