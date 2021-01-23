    public static void Main()
    {
        var x = 2;
        switch (x)
        {
            case 1: {  // notice these braces I added
                var foo = "one";
                Console.Out.WriteLine(foo);
                break;
            }
            case 2:
                foo = "two"; // hooray! foo is no longer in scope here
                Console.Out.WriteLine(foo);
                break;
        }
    }
