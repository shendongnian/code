    public string SomeProperty{
        get{return "I like pie!";}
        set{
            if(string.Compare(value, "pie", StringComparison.OrdinalIgnoreCase) == 0)
                Console.WriteLine("Pie is yummy!");
            else Console.WriteLine("\"{0}\" isn't pie!", value ?? "<null>");
        }
    }
