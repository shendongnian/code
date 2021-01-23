        [Test]
        public void If_Enter_first_then_return_empty_pwd()
        {
            // Arrange
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> { ConsoleKey.Enter });
            var expectedResult = String.Empty;
            var expectedConsoleOutput = String.Empty;
            // Act
            var actualResult = Program.GetMaskedInput(string.Empty, stub);
            //     
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(stub.Output, Is.EqualTo(expectedConsoleOutput));
        }
        [Test]
        public void If_two_chars_return_pass_and_output_coded_pass()
        {
            // Arrange
            var stub = new ConsoleWrapperStub(new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.B, ConsoleKey.Enter });
            var expectedResult = "AB";
            var expectedConsoleOutput = "**";
            // Act
            var actualResult = Program.GetMaskedInput(string.Empty, stub);
            //     
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(stub.Output, Is.EqualTo(expectedConsoleOutput));
        }
