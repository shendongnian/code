    // Arrange
    var model = MockRepository.GenerateMock<IMockIRuleRuningViewModel>();
    model.Expect(m => m.ProcessEngineResults(42));
    RulesEngine engine = new RulesEngine(model);
    
    // Act
    engine.RunRule("Id");
    
    // Assert
    model.VerifyAllExpectations();
