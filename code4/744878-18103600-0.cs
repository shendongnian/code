    DataContractSerializer serialiser = new DataContractSerializer(typeof(List<BooksModels>));
    List<BooksModels> expected = business.GetBooksList();
    Stream stream = new MemoryStream();
    serialiser.WriteObject(stream, expected);
    stream.Position = 0;
    List<BooksModels> actual = serialiser.ReadObject(stream) as List<BooksModels>;
    Assert.IsNotNull(actual);
    Assert.AreEqual(expected.Prop1, actual.Prop1);
    Assert.AreEqual(expected.Prop2, actual.Prop2);
    // ... //
