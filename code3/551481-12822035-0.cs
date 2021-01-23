    var mustExit = false;
    using (var oracleConnection = getOracleConnection()) {
        try {
            ...
        } catch {
            Console.WriteLine("Failure getting applicant records: " + ex.Message);    
            mustExit = true;
        }
    }
    if (mustExit) {
        System.Environment.Exit(0);                
    }
