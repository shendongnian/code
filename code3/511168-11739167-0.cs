    static void Main()
    {
       int a;
       int b;
       someFunction(out a,out b); //the int values will be returned in a and b
       Console.WriteLine(a);
       Console.WriteLine(b);
    }
    public static void someFunction(out int x,out int y)
    {
       x=10;
       y=20;
     }
