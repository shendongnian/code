        moqIEventLogger.Setup(s => s.WriteError(It.IsAny<Exception>(), 
                                           It.IsAny<string>()))
                      .Callback<Exception ex, string s>(p =>
                      {
                             throw ex;
                      });
