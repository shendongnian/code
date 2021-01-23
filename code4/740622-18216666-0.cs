    var isConnected = false;
    var stub = MockRepository.GenerateStub<IConnected>();
    stub
        .Stub(c => c.IsConnected)
        .Do((Func<bool>)(() => isConnected))
        .Return(false);
    stub
        .Stub(c => c.Connect())
        .Do((Action)(() => { isConnected = true; }));
