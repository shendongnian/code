    engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
    
    records = engine.ReadFile(...
    
    if (engine.ErrorManager.HasErrors)
       foreach (ErrorInfo err in engine.ErrorManager.Errors)
       {
          Console.WriteLine(err.LineNumber); 
          Console.WriteLine(err.RecordString);
          Console.WriteLine(err.ExceptionInfo.ToString());`
       }
     
