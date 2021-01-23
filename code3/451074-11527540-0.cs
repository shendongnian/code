    [TestClass]
    public class UnitTest1
    {
            [ClassInitialize]
            public static void Init(TestContext context)
            {
                Mock.Replace<FileInfo, string>(x=> x.Extension).In<UnitTest1>();
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
