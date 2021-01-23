    [TestClass, MockClass] // **MockClass Added**
    public class UnitTest1
    {
            [ClassInitialize]
            public static void Init(TestContext context)
            {
                 Mock.Partial<FileInfo>().For<FileInfo, string>(x => x.Extension);
            }
 
           [TestMethod]
           public void ShouldAssertFileInfoExtension()
           {
               var fileInfo = Mock.Create<FileInfo>(Constructor.Mocked);
     
               string expected = "test";
     
               Mock.Arrange(() => fileInfo.Extension).Returns(expected);
     
               Assert.AreEqual(fileInfo.Extension, expected);
           }
     
    }
