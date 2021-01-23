    var handlingManager = new ExceptionHandlingManager();
    handlingManager
     .For<Exception>()
       .HavingAMessage(message => message.Includes("something went bad"))
       .WithInnerException<SomeInnerException>()
         .HavingAMessage(innerMessage => innerMessage == "Something inside went bad as well")
       .Perform(() => 
       {
         DoX();
         DoY();
       });
