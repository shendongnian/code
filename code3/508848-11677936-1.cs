    // Add the target entity     
    Entity myStubbedEntity = new Entity("account");
    // set properties on myStubbedEntity specific for this test...
    ParameterCollection inputParameters = new ParameterCollection();     
    inputParameters.Add("Target", myStubbedEntity);     
    pipelineContext.Stub(x => x.InputParameters).Return(inputParameters); 
