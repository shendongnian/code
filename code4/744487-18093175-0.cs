    public class TestFirst : first.ThirdParty.Foo.Something
    {
        //here you shadow and since you must provide the alias
        //and the fully qualified name it will bet set to the
        //right Bar class,same bellow in testsecond.
        public first.ClassLibrary4.Bar MyProperty { get; set; }
    }
    
    public class TestSecond : second.ThirdParty.Foo.SomethingElse
    {
        public second.ClassLibrary4.Bar MyProperty { get; set; }
    }
