    public static void Check(Base BB){
     foreach (var c in BigList)
        {
            if (c.CompareTo(bb) < 0)
                Console.WriteLine("Less Than");
            else if (c.CompareTo(bb) == 0)
                Console.WriteLine("Equal");
            else if (c.CompareTo(bb) > 0)
                Console.WriteLine("Greater Than");
        }
    }
