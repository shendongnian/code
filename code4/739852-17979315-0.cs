      var engine = new FileHelperEngine<MyClass>();
      engine.Options.IgnoreFirstLines = 1;
      engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
      engine.AfterReadRecord += new FileHelpers.Events.AfterReadHandler<MyClass>(engine_AfterReadRecord);
 
