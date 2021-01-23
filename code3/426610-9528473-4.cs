    //both methods have the same name and depending on wether you pass in a parameter
    //or not, the first or the second is used.
    public static void SayHello() {
        Console.WriteLine("Hello");
    }
    public static void SayHello(string message) {
        Console.WriteLine(message);
    }
