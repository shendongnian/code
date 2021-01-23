        var counter = MockRepository.GenerateStub<ICounter>();
        int cnt = 1;
        counter
            .Stub(c => c.GetCounter)
            .Do((Func<int>)(() => cnt));
        counter
            .Stub(c => c.IncreaseCounter())
            .Do((Action)(() => ++cnt));
