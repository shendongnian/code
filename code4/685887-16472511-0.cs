    struct foo
    {
        public int x;
        public foo(int y)
        {
            x = y;
        }
    }
    static void Main()
    {
        foo myFoo1 = new foo(10);
        foo myFoo2 = myFoo1;
        myFoo2.x = 5;
        Console.WriteLine(myFoo1.x); // 10
    }
