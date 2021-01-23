    // allLines is your List/Array/Enumerable of all lines that need checking
    foreach(string line in allLines){
        if(!line.Trim().StartsWith("."){
            // Do whatever you like with the found string.
            line = line.Remove(".",1);
        }
    } 
