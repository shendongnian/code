    public void Bar(Foo foo)
    {
        if (foo.GetType().Assembly != this.GetType().Assembly)
            throw new InvalidOperationException("It's not one of mine!");
    }
    
    public class Foo
    {
    }
