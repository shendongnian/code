    validatorStub.Stub(x => x.IsValid(Arg<string>.Is.Anything, Arg<string>.Is.Anything, ref Arg<string>.Ref(Rhino.Mocks.Constraints.Is.Anything(), "123456").Dummy));
    
    string testRefValue = "";
    validatorStub.IsValid("1", "2", ref testRefValue);
    Assert.AreEqual("123456", testRefValue);
