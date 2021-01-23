    int i1 = 34;
    int i2 = 34;
    Console.WriteLine(i1 == i2);             // gives true
    object o1 = i1;
    object o2 = i2;
    Console.WriteLine(o1 == o2);             // gives false
    Console.WriteLine((int)o1 == (int)o2);   // gives true
    Console.WriteLine(o1.Equals(o2));        // gives true
