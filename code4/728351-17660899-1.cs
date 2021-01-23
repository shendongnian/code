    public void RunThis()
    {
        var stubReader = MockRepository.GenerateStub<IInterface>();
        stubReader.Stub(sr => sr.GetDecimal()).Return(1.2);
    }
