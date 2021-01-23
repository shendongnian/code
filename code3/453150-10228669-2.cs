    public class Foo : List<Bar>
    {
        private struct Bar { }
    }
    
    var myFoo = new Foo();
    ...
    var x = myFoo()[0]; // expression on the right side is of type Bar, yet Bar is inaccessible
