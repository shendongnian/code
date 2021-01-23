        [Test]
        public void GetMessage_Input1_ReturnEnterAccountNumberMessage()
        {
            var result = GetMessage("1");
            var expected = "Enter Account Number: ";
            Assert.That(result == expected);
        }
        [Test]
        public void GetMessage_Input2_ReturnHelloWorldMessage()
        {
            var result = GetMessage("1");
            var expected = "Hello World!";
            Assert.That(result == expected);
        }
