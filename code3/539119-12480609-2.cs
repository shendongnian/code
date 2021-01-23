    [TestMethod]
    public void SomeMethod_Should_Write_Some_Expected_Output()
    {
        // arrange
        using (var stream = new MemoryStream())
        using (var writer = new StreamWriter(stream))
        {
            // act
            sut.SomeMethod(writer);
        
            // assert
            string actual = Encoding.UTF8.GetString(stream.ToArray());
            Assert.AreEqual("some expected output", actual);
        }
    }
