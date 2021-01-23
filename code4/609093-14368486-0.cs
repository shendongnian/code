    int callCounter = 0;
    var mock = new Mock<IWhatever>();
    mock
        .Setup(mock => mock.SomeMethod())
        .Returns(() => 
        {
           if (callCounter++ < 10)
           {
               // do something
           }
           else
           {
               // do something else
           }
        });
