    public static class MyClass {
        public string MyMethod (Base @base) {
            return @base.Foo ();
        }
    }
    [Test]
    public void then_it_should_return_non_null () {
        var obj = new Inherited ();
        var result = MyClass.MyMethod(obj);  // obj will get upcasted to Base
        Assert.That (result, Is.EqualTo(obj.Foo ())); // Assert fails!
    }
    [Test]
    public void inherited_should_return_correct_value ()
    {
        var obj = new Inherited ();
        var result = obj.Foo ();  // will access the "new" method, hiding Base's implementation
        Assert.That (result, Is.Not.Null);  // Assert passes! 
    }
