    //nonsense class
    public class Foo {
        public string Bar { get; set; }
        public bool IsClosed { get; private set; }
        public void Close() {
            IsClosed = true;
        }
    }
    
    //nonsense event.
    public event Action<Foo> SomeEvent;
    
    void BindAndFire() {
        //wire it up.
        SomeEvent += (foo) => { 
            var a = DateTime.Now.Millisecond % 2;
            foo.Bar = (a == 0) ? "Hooray" : "Boo";
        };
        SomeEvent += (foo) => { 
            if(foo.Bar != "Boo") {
               foo.Close();
            }
        };
        SomeEvent += (foo) => { 
            foo.Bar += ", you made it!";
        };
    
        //fire the event.
        var f = new Foo();
        foreach(var s in SomeEvent.GetInvocationList()) {
            s.DynamicInvoke(f);
            if(f.IsClosed) break;
        }
    }
