    [Test]
    public void TestFileIO()
    {
       var mock = new Mock<IMyFileIO>();
       mock.Setup(foo => foo.ReadFromFile(2)).Returns(new byte[]{2,3});
    
       var myResult = MyClass.GetStuff(mock.Object, 10);
       Assert. // <- what you need to check
    }
