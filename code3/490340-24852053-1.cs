    var perms = new Permutations();
    
    var sw1 = Stopwatch.StartNew();
    perms.Permutate(0,
                    11,
                    (Action<int[]>)null); // Comment this line and...
                    //PrintArr); // Uncomment this line, to print permutations
    sw1.Stop();
    Console.WriteLine(sw1.Elapsed);
