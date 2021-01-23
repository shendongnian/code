    [Test]
    public void SetCookie()
    {
      var c1 = MvcMockHelpers.FakeHttpContext();
      var aCookie = new HttpCookie("userInfo");
      aCookie.Values["userName"] = "Tom";
    
      var mockedRequest = Mock.Get(c1.Request);
      mockedRequest.SetupGet(r => r.Cookies).Returns(new HttpCookieCollection());
      c1.Request.Cookies.Add(aCookie);
    
      Debug.WriteLine(c1.Request.Cookies["userInfo"].Value);
    }
