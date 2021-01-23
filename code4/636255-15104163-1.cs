    void Main()
    {
        var src = "ABCDEF";
        var combos = PowerSet(src, 3, 6);
        
        // hairy joins for great prettiness
        Console.WriteLine(
            string.Join(" , ", 
                combos.Select(subset => 
                    string.Concat("[", 
                        string.Join(",", subset) , "]")))
        );
    }
