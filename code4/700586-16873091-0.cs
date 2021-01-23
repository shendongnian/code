    ....
    int x;
    string s;
    do
    {
        Console.WriteLine("input a number in the range of 0 -100");
        s = Console.ReadLine();
        if(!Int32.TryParse(s, out x)
            x = -1;
     }
    while (x < 0 || x > 100);
    ...
