    {
        var testVariable = "blah";
        // Create variable outside the if scope
        Data selectedData = null; // Now it compiles. :)
        //set cache key and query based their being a craft name
        if(testVariable.Length > 0)
        {
    
            var db = Database.Open("Connection"); 
            // Assign a value to a variable
            selectedData = db.Query("SELECT * FROM Products");          
        } 
        // Variable still exist!
    }
    // Here, variable would cease to exist. :(
