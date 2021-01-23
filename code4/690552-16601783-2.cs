    int a = 1;
    var myQueue = new Queue<int>();
    myQueue.Enqueue(a);
    a = 2;
    //Prints 1
    Console.WriteLine(myQueue.First());
    //Prints 2
    Console.WriteLine(a);
