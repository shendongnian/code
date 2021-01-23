    Console.Write("Enter Number of elements in Array: ");
    arraySize = int.Parse(Console.ReadLine());
    intArray = new int[arraySize];
    
    Console.WriteLine("Please enter an array of numbers: ");
    
    for (int i = 0; i < intArray.Length; i++)
    {
        intArray[i] = Int32.Parse(Console.ReadLine());
    }
