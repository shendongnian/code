    public void addTwo(int a)
    {
        a += 2;
    }
    ...
    int a = 5;
    addTwo(a);
    Console.WriteLine(a); // will give "5";
--------------------------------------------
    public void addTwo(ref int a)
    {
        a += 2;
    }
    ...
    int a = 5;
    addTwo(ref a);
    Console.WriteLine(a); // will give "7";
