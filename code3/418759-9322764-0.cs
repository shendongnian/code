    Interface1 interface1 = MockRepository.GenerateStub<Interface1>();
    int i = 1;
    interface1.Stub(x => x.Method1(ref Arg<int>.Ref(Is.Anything(), i).Dummy);
    int j = 0;
    interface1.Method1(ref j);
    if (j == 1) Console.WriteLine("OK");
