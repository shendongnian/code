    void Mutate(SomeObject x)
    {
         x.val = "banana";
    }
    void Reassign(SomeObject x)
    {
         x = new SomeObject();
         x.val = "Garbage";
    }
    public static void Main()
    {
         SomeObject x = new SomeObject();
         x.val = "Apple";
         Console.WriteLine(x.val); // Prints Apple
         Mutate(x);
         Console.WriteLine(x.val); // Prints banana
         Reassign(x);
         Console.WriteLine(x.val); // Still prints banana
    }
