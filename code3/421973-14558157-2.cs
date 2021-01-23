    var handlingManager = new ExceptionHandlingManager();
    handlingManager
     .For<Exception>()
       .HavingAMessageThatIncludes("something went bad")
       .WithInnerException<SomeInnerException>()
         .HavingAMessageEqualTo("Something inside went bad as well")
       .Perform(() => 
       {
         DoX();
         DoY();
       });
