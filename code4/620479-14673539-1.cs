    [Test]
    public void StreamReadingEventAddsStreamToEventArgsWhenFileExists()
    {
         var e new StreamReadingEventArgs { e.AlternateStreamName= "Random string in path format", e.FileMode = AnyFileMode(), e.FileAccess = AnyFileAccess() };
         var expectedStream = new MemoryStream();
         _fileSystemMock.Setup(f=>f.OpenFile(e.AlternateStreamName, e.FileMode, e.FileAccess)).Returns(expectedStream);
    
         SomehowFireTheEvent(e);
    
         Assert.That(e.AlternateStream, Is.SameAs(expectedStream));
    }
