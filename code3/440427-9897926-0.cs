    [Test]
      public void ValidateProducerTest()
      {
         bool anyBooleanValue = true;
         IOptionalParameterTester optionalParameter = MockRepository.GenerateStub<IOptionalParameterTester>();
    
         optionalParameter.Stub(x => x.IsValid(anyBooleanValue)).Return(true);
      }
