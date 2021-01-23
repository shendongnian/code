    int x = 5;
    int y = 3;
    int *ptr1 = &x; // point to x memory address
    int *ptr2 = &y; // point to y memory address
    
    Console.WriteLine(x); // print 5
    Console.WriteLine(y); // print 3
    
    Console.WriteLine((int)ptr1); // print 5
    Console.WriteLine((int)ptr2); // print 3
    Console.WriteLine(*ptr1); // print 5
    Console.WriteLine(*ptr2); // print 3
