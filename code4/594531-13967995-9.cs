    public void If_Enter_first_then_return_empty_pwd()
    {
        // Arrange
        var stub = new ConsoleWrapperStub(new List<ConsoleKeyInfo> { ConsoleKey.Enter });
        var expectedResult = String.Empty;
        var expectedConsoleOutput = String.Empty;
        // Act
        var actualResult = getMaskedInput(string.Empty, stub);
        //     
         Assert.That(actualResult, Is.EqualTo(expectedResult));
         Assert.That(stub.Output, Is.EqualTo(expectedConsoleOutput));
    }
