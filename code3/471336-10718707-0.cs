      var _mockCache = new Mock<Cache>();
      _mockCache.Setup(m => m.Get(It.IsAny<string>())).Returns(null);
      _mockCache.CallBase = true;
      var output = _mockCache.Object.GetOrStore("foo", () => "Foo", 100);
      Assert.AreEqual("Foo", output);
