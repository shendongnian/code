    public static class ExtensionMethods { 
        public static void Foo(this Bar b, Thingamabob t) {
            // Access t to enable this extension method to do its work, whatever that may be
        }
    }
    
    public class Bar { }
    
    public class Schlemazel {
        public void DoSomething() {
            using (Thingamabob t = new Thingamabob()) {
                Bar b = new Bar();
                b.Foo(t);
            }
        }
    }
