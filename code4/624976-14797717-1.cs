        [Test]
        public void SendEmail()
        {
            var clientMock = MockRepository.GenerateMock<IEmailClient>();
            // define behaviour for clientmock
            var sut = new EmailThingy(clientMock);
            sut.SendMail();
        }
