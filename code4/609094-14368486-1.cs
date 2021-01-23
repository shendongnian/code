    int callCounter = 0;
    var mock = new Mock<IWhatever>();
    mock.Setup(a => a.SomeMethod())
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
