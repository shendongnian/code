    static class Test
    {
        public static string logged_in;
    }
    
    
    Test.logged_in = "true";
    var t = Test.logged_in;
    Console.WriteLine(l); // prints "true"
    Test.logged_in = "false";
    var f = Test.logged_in;
    Console.WriteLine(f); // prints "false"
    Console.WriteLine(t); // prints "false"
