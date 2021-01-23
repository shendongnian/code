    [Test]
    public void Test(){
        var arguments = new[]{"aa", "bb", "cc"};
        var mock = new Mock<TextWriter>();
        int index = 0;
        mock.Setup(tw => tw.WriteLine(It.IsAny<string>()))
            .Callback((string s) => Assert.That(s, Is.EqualTo(arguments[index++])));
    
        Do(arguments, mock.Object);
        mock.Verify();
    }
