    var list = new List<string>();
    list.Add("Hello");
    list.Add("World");
    Console.WriteLine(list[0]); // ==> "Hello"
    Console.WriteLine(list[1]); // ==> "World"
    foreach (string s in list) {
        Console.WriteLine(s);
    }
    // Output:  Hello
    //          World
