    List<int> a = new List<int>();
    List<int> b = a;
    Console.WriteLine(Object.ReferenceEquals(a, b)); //true
    a.Add(1);
    Console.WriteLine(a[0]); //1
    Console.WriteLine(b[0]); //1
    a[0] = 9000;
    Console.WriteLine(a[0]); //9000
    Console.WriteLine(b[0]); //9000
