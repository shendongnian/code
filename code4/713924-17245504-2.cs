    Public Class Foo
    {
        Public Foo(IBar bar)
        {
            bar.Create(typeof(Foo));
        }
    }
