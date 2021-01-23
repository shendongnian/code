    var rnd = new Random();
    //var data = Enumerable.Range(0, 10).ToArray();
    var data = Enumerable.Range(0, 10).Select(x => rnd.Next(1 << 13)).ToArray();
    
    foreach (var n in data) Console.WriteLine(n);
    
    Console.WriteLine(new string('-', 13));
    
    var bits = new BitArray(data.Length * 13);
    
    for (int i = 0; i < data.Length; i++)
    {
        var intBits = new BitArray(new[] { data[i] });
        for (int b = 12; b > -1; b--)
        {
            bits[i * 13 + b] = intBits[b];
            Console.Write(intBits[b] ? 1 : 0);
        }
        Console.WriteLine();
    }
    Console.WriteLine(new string('-', 13));
    
    for (int i = 0; i < bits.Length / 13; i++)
    {
        int number = 0;
        for (int b = 12; b > -1; b--)
            if (bits[i * 13 + b])
                number += 1 << b;
    
        Console.WriteLine(number);
    }
    Console.ReadLine();
