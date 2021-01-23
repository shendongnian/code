    public string get_SomeProperty(){return "I like pie!";}
    public void   set_SomeProperty(string value){
        if(string.Compare(value, "pie", StringComparison.OrdinalIgnoreCase) == 0)
            Console.WriteLine("Pie is yummy!");
        else Console.WriteLine("\"{0}\" isn't pie!", value ?? "<null>");
    }
