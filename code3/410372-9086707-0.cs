    public static void RunSnippet()
    {
        List<int> hello = new List<int>();
        List<int> additions = new List<int>();
        hello.Add(1); hello.Add(2); hello.Add(3);
    
        foreach (var x in hello)
        {
            Console.WriteLine(x);
            if (x == 1) {
                additions.Add(100);
            }
        }
    
        hello.AddRange(additions);
    }
