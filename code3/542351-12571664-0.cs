    class foo
    {
        public virtual void dosomething()
        {
             console.writeline("this is foo");
        }
    }
    class bar : foo
    {
        public override void dosomething()
        {
             console.writeline("this is bar");
        }
    }
    var list = new Foo[]{new foo(), new bar()};
