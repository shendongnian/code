    [Test]
    public void Get_Commands_ReturnsCorrectNumberOfCommands()
    {
       const string InputString = 
           "150" + Environment.NewLine + 
           "10" + Environment.NewLine;
       var stringReader = new StringReader(InputString);
       var actualCommandsNumber = MyClass.Get_Commands(stringReader);
       Assert.That(actualCommandsNumber, Is.EqualTo(10));
    }
