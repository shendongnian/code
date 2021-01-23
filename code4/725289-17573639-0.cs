    int[][] test = new int[2][];  //Declaring the array of arrays.
    
    for (int i = 0; i < test.Length; i++)
    {
        test[i] = new int[5];  //Instantiating a sub-arrays.
        for (int x = 0; x < test[i].Length; x++)
            test[i][x] = x + i;  //Filling a sub-arrays.
    }
    
    foreach (var array in test)  //iterating over the array of arrays.
        Console.WriteLine("Array: " + string.Join(", ", array));  //using a sub-array
    Console.ReadLine();
