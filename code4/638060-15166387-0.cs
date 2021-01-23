    using Microsoft.SqlServer.SqlWmiManagement;
    
    // .net implicitly loads assembly when current class is instantiated
    
    // ... code ...
    
    try {
       // problem method using missing assembly
    } 
    catch {
       // this is ineffective because the ass'y load already failed before the try block
    }
