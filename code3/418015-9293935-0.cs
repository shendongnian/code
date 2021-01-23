    // arrange
    var dataAccessApi = MockRepository.GenerateMock<IDataAccessApi>();
    var restExecution = MockRepository.GenerateMock<IRestExecution>();
    var sinkNodeResource = new SinkNodeResource(dataAccessApi, restExecution);
    string uri = "http://SomeUri.com";
    string sourcePath = "Some Source Path";
    // act
    sinkNodeResource.CopyToUserSession(uri, sourcePath);
    // assert
    dataAccessApi.AssertWasCalled(
        x => x.Request<object>(
            Arg<RestRequest>.Matches(
                y => y.Method == Method.POST && 
                     y.Resource == uri &&
                     y.Parameters.Count == 1 &&
                     y.Parameters[0].Value as string == sourcePath
            ),
            Arg<Action<object>>.Is.Equal((Action<object>)restExecution.Get)
        )
    );
