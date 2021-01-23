    class Foo { public virtual void DoFoo() { Console.WriteLine("Foo"); } }
    class Bar:Foo { public override sealed void DoFoo() { Console.WriteLine("Bar"); } }
    class Baz:Bar { public virtual void DoFoo() { Console.WriteLine("Baz"); } }
    class Bai:Baz { public override void DoFoo() { Console.WriteLine("Bai"); } }
    class Bat:Bai { public new void DoFoo() { Console.WriteLine("Bat"); } }
    class Bak:Bat { }
    Foo foo = new Foo();
    Bar bar = new Bar();
    Baz baz = new Baz();
    Bai bai = new Bai();
    Bat bat = new Bat();
    foo.DoFoo();
    bar.DoFoo();
    baz.DoFoo();
    bai.DoFoo();
    bat.DoFoo();
    Console.WriteLine("---");
    Foo foo2 = bar;
    Bar bar2 = baz;
    Baz baz2 = bai;
    Bai bai2 = bat;
    Bat bat2 = new Bak();
    foo2.DoFoo();
    bar2.DoFoo();
    baz2.DoFoo();
    bai2.DoFoo();    
    Console.WriteLine("---");
    Foo foo3 = bak;
    Bar bar3 = bak;
    Baz baz3 = bak;
    Bai bai3 = bak;
    Bat bat3 = bak;
    foo3.DoFoo();
    bar3.DoFoo();
    baz3.DoFoo();
    bai3.DoFoo();    
    bat3.DoFoo();
