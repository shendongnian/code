    var counter = MockRepository.GenerateStub<ICounter>();
    int x = 1;
    int y = 2;
    int cnt = x;
    counter
        .Stub(c => c.GetCounter)
        .Return(0)
        .WhenCalled(invocation =>
        {
            invocation.ReturnValue = cnt;
            cnt = y;
        });
