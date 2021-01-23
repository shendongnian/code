    [TestMethod]
    public void BaseFoo_object_Equals_returns_true_for_Foos_with_same_Identification()
    {
        var id = "testId";
        var foo1 = MockRepository.GenerateStub<BaseFoo>();
        var foo2 = MockRepository.GenerateStub<BaseFoo>();
        foo1.Stub(x => x.Identification).Return(id);
        foo2.Stub(x => x.Identification).Return(id);
    	foo1.Stub(x => ((object)x).Equals(Arg<object>.Is.Anything)).CallOriginalMethod(OriginalCallOptions.NoExpectation);
        Assert.IsTrue(((object)foo1).Equals(foo2));
    }
