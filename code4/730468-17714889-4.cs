    void AnyMethod()
    {
        var result = // ...
    
        HandleException.GlobalTryCatch(() => { /* action 1 */}, result);
    
        // should we check result to continue?
        // if so, this is a typical error-code approach, which annihilates 
        // all preferences, provided by .NET exceptions;
        // if we shouldn't check it, what would be the behavior of our code,
        // if the state is broken after action 1? 
    
        HandleException.GlobalTryCatch(() => { /* action 2 */}, result);
      
        // the same questions
    
        HandleException.GlobalTryCatch(() => { /* action 3 */}, result);
    }
