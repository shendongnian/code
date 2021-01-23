            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var myInterface = fixture.Freeze<Mock<IFileConnection>>();
            var sut = fixture.CreateAnonymous<Transfer>();
            myInterface.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<System.IO.IOException>();
            sut.Invoking(x => x.GetFile(myInterface.Object, It.IsAny<string>(), It.IsAny<string>()))
                .ShouldThrow<System.IO.IOException>();
