    [Test]
    public void Correct_Loader_Method_is_Used()
    {
        const int userId = 1;
        var companies = new[] { "c1", "c2" };
        var dataLoader = MockRepository.GenerateMock<ITestDataLoader>();
        var dataConsumer = MockRepository.GenerateMock<IDataConsumerClass>();
        var testObject = new TestClass(dataLoader, dataConsumer);
        dataConsumer.Expect(fc => fc.LoadIt(Arg<Func<IEnumerable<string>>>.Matches(x => x().Any()))).Return(true);
        //validate that correct dataloader function was called...
        dataLoader.Expect(dl => dl.LoadCompanies(userId)).Return(companies);
        // Fails if you uncomment this line
        //dataLoader.Expect(dl => dl.LoadEmployees(userId)).Return(companies);
        var result = testObject.Run(userId);
        Assert.That(result, Is.True);
        dataLoader.VerifyAllExpectations();
        dataConsumer.VerifyAllExpectations();
    }
