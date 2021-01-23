    string userMessage; // class scope
    
    ...
    if (condition) {
         String userMessage = "blah"; // only available until the closing brace
    } // out of scope here
