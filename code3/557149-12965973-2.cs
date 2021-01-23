    public static class MyClass {
        public string MyMethod (Base @base) {
            return @base.Foo ();
        }
    }
    [Test]
    public void then_it_should_return_non_null () {
        var obj = new Inherited ();
        var result = MyClass.MyMethod(obj);
        Assert.That (result, Is.EqualTo(obj.Foo())); // Assert fails!
    }
