    var mockA = MockRepository.GenerateMock<IA>();
    mockA
        .Stub(x => x.DoSomething(Arg<IC>.Is.Anything))
        .Do((Func<IC, IB>)(arg => new B(arg)))
        .Return(null);
