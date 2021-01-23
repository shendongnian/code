    [Test]
    public void SearchOneRecord()
    {
        //Arrange
        var configuratorMock = MockRepository.GenerateMock<ISearchConfigurator>();
        var directorySearcherMock = MockRepository.GenerateMock<IDirectorySearcher>(); // please note I don't know exact type, so you need to ammend it
        var returnValue = ... // initialize with types you expect DirectorySearcher to return
        var searcher = new Searcher(); // initialize class you actually want to test
        configurationMock.Replay();
        configurationMock.Expect(x => x.DirectorySearcher).Return(directorySearcherMock);
        directorySearcher.Expect(x => x.FindOne()).Return(returnValue);
        searchMock.Expect(x => x.SearchOneRecord(configuratorMock)).Return(nativeDs);
        //Act
        var record = searcher.SearchOneRecord(configuratorMock);
        //Assert
        Assert.AreEqual(nativeDs.PasswordAge, record.PasswordAge);
    }
