    public void RhinoMocksSampleTest()
    {
        var workerMock = MockRepository.GenerateMock<IWorker>();
        workerMock.Expect(d => d.DoWork(Arg<MyObject>.Matches(r => r.Name == "PersonA")));
        workerMock.Expect(d => d.DoWork(Arg<MyObject>.Matches(r => r.Name == "PersonB")));
        var myObj = new MyObject { Id = 1, Name = "PersonA" };
        var p = new Program();
        p.DoWork(workerMock , myObj);
        workerMock.VerifyAllExpectations();
    }
