    // There's no need to initialize cValue since it's used as an 
    // out parameter by TryParse which guarantees initialization.
    // If TryParse fails the output parameter will be set it to 
    // default(T), where T is double in this case, i.e. 0.
    double cValue; 
    
    if( Double.TryParse( line[8], out cValue ) )
    {
        // success (cValue is now the parsed value)
    }
    else
    {
        // failure (cValue is now 0)
    }
