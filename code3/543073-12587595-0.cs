    int[] DaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; 
    Console.Write("enter the number of the month: "); 
    int month = Convert.ToInt32(Console.ReadLine()); 
    Console.WriteLine("that month has {0} days", DaysInMonth[month - 1]); 
    WriteIt("some string"); <====== //add this
