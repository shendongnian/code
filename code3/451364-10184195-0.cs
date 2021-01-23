    var multiDimensionalList = new List<List<string>>{
    	new List<string>{"A","B","C"},
    	new List<string>{"D","E","F"},
    	new List<string>{"G","H","I"},
    };
    Console.WriteLine(multiDimensionalList[2][1]); // Prints H
    
    multiDimensionalList[2].RemoveAt(1); // Removes the second item in the third list
    Console.WriteLine(multiDimensionalList[2][1]); // Prints I
