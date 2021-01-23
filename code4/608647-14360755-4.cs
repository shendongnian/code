    [TestClass]
    public class HomeControllerTests : TestControllerBuilder
    {
        private HomeController sut;
        [TestInitialize]
        public void TestInitialize()
        {
            this.sut = new HomeController();
            this.InitializeController(this.sut);
        }
        [TestMethod]
        public void PrintCSV_Should_Stream_The_Bytes_Argument_For_Download()
        {
            // arrange 
            var bytes = new byte[] { 1, 2, 3 };
            var fileName = "foobar";
            // act
            var actual = sut.PrintCSV(bytes, fileName);
            // assert
            var file = actual.AssertResultIs<FileContentResult>();
            Assert.AreEqual(bytes, file.FileContents);
            Assert.AreEqual("application/vnd.ms-excel", file.ContentType);
            this.HttpContext.Response.AssertWasCalled(
                x => x.AppendHeader(
                    Arg<string>.Is.Equal("Content-Disposition"),
                    Arg<string>.Matches(cd => cd.Contains("attachment;") && cd.Contains("filename=" + fileName))
                )
            );
        }
    }
