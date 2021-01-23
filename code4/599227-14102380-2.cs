        var counter = MockRepository.GenerateStub<ICounter>();
        int cnt = 1;
        counter
            .Stub(c => c.GetCounter)
            .Return(0)
            .WhenCalled(invocation => { invocation.ReturnValue = cnt; });
        counter
            .Stub(c => c.IncreaseCounter())
            .WhenCalled(invocation => { ++cnt; });
