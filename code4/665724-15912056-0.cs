    public class Foo
    {
        public string Message {get;set;}
    }
    public class Bar
    {
        public void Boz()
        {
            var foo = new Foo();
            foo.Message = "Working";
        }
    }
