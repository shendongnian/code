    public void Test()
    {    
        var intArray = new[] {1, 2, 3, 4};
        EditArray(intArray);
        Console.WriteLine(intArray[0].ToString()); //output will be 0
    }
    public void EditArray(int[] intArray)
    {
        intArray[0] = 0;
    }
    
   
