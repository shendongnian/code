    IActionVisitor<Letter> visitor = Visitor.For<Letter>();
    visitor.Register<A>(x => Console.WriteLine(x.GetType().Name));
    visitor.Register<B>(x => Console.WriteLine(x.GetType().Name));
    Letter a = new A();
    Letter b = new B();
    visitor.Visit(a);
    visitor.Visit(b);
