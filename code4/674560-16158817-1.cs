    if (!ValidMenuOption){
        string errorMsg = "\n\t Option must be ";
        int iteration = 1;
        while (iteration <=numAvailable) {                        
            errorMsg = errorMsg + iteration + ", ";
            iteration+=1;
        }
        errorMsg = errorMsg + "or 0"; 
        Console.WriteLine(errorMsg);
    }
