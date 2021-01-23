    [TestMethod]
    public void PrintCSV_Should_Stream_The_Bytes_Argument_For_Download()
    {
        // arrange 
        var sut = new HomeController();
        var bytes = new byte[] { 1, 2, 3 };
        var fileName = "foobar";
        var httpContext = MockRepository.GenerateMock<HttpContextBase>();
        var response = MockRepository.GenerateMock<HttpResponseBase>();
        httpContext.Expect(x => x.Response).Return(response);
        var requestContext = new RequestContext(httpContext, new RouteData());
        sut.ControllerContext = new ControllerContext(requestContext, sut);
    
        // act
        var actual = sut.PrintCSV(bytes, fileName);
    
        // assert
        Assert.IsInstanceOfType(actual, typeof(FileContentResult));
        var file = (FileContentResult)actual;
        Assert.AreEqual(bytes, file.FileContents);
        Assert.AreEqual("application/vnd.ms-excel", file.ContentType);
        response.AssertWasCalled(
            x => x.AppendHeader(
                Arg<string>.Is.Equal("Content-Disposition"),
                Arg<string>.Matches(cd => cd.Contains("attachment;") && cd.Contains("filename=" + fileName))
            )
        );
    }
