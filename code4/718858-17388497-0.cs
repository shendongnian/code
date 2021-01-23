    List<int[]> myList = new List<int[]>(); // <- MyList is list of arrays of int
    
    // Let's add some values into MyList; pay attention, that arrays are not necessaily same sized arrays:
    
    myList.Add(new int[] {1, 2, 3});
    myList.Add(new int[] {4, 5, 6, 7, 8});
    myList.Add(new int[] {}); // <- We can add an empty array if we want
    myList.Add(new int[] {100, 200, 300, 400});
    
    // looping through MyList and arrays 
    
    int[] line = myList[1]; // <- {4, 5, 6, 7, 8}
    int result = line[2]; // <- 6
    
    // let's sum the line array's items: 4 + 5 + 6 + 7 + 8
    
    int sum = 0;
    
    for (int i = 0; i < line.Length; ++i)
      sum += line[i];
    // another possibility is foreach loop:
    sum = 0;
    foreach(int value in line) 
      sum += value;   
    
    // let's sum up all the arrays within MyList
    totalSum = 0;
    for (int i = 0; i < myList.Count; ++i) {
      int[] myArray = myList[i];
    
      for (int j = 0; j < myArray.Length; ++j)
        totalSum += myArray[j];  
    }
    // the same with foreach loop
    totalSum = 0;
    foreach(int[] arr in myList)
      foreach(int value in arr) 
        totalSum += value; 
