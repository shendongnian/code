    using System;
    
    class Program
    {
        static void Main()
        {
    	int[] arr1 = new int[] { 3, 4, 5 }; // Declare int array
    	int[] arr2 = { 3, 4, 5 };           // Another
    	var arr3 = new int[] { 3, 4, 5 };   // Another
    
    	int[] arr4 = new int[3];            // Declare int array of zeros
    	arr4[0] = 3;
    	arr4[1] = 4;
    	arr4[2] = 5;
    
    	if (arr1[0] == arr2[0] &&
    	    arr1[0] == arr3[0] &&
    	    arr1[0] == arr4[0])
    	{
    	    Console.WriteLine("First elements are the same");
    	}
        }
    }
    using System;
    
    class Program
    {
        static void Main()
        {
    	// Loop over array of integers.
    	foreach (int id in GetEmployeeIds())
    	{
    	    Console.WriteLine(id);
    	}
    	// Loop over array of integers.
    	int[] employees = GetEmployeeIds();
    	for (int i = 0; i < employees.Length; i++)
    	{
    	    Console.WriteLine(employees[i]);
    	}
        }
    
        /// <summary>
        /// Returns an array of integers.
        /// </summary>
        static int[] GetEmployeeIds()
        {
    	int[] employees = new int[5];
    	employees[0] = 1;
    	employees[1] = 3;
    	employees[2] = 5;
    	employees[3] = 7;
    	employees[4] = 8;
    	return employees;
        }
    }
    
    Output
    
    1
    3
    5
    7
    8
    1
    3
    5
    7
    8
