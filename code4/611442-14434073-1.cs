    [SetUp]
    public void SetUp()
    {
        workbook = MockRepository.GenerateMock<Workbook>();
        memoryStream = MockRepository.GenerateMock<MemoryStream>();
        fileFormatLookup = new FileFormatLookup(workbook, memoryStream);
    }
