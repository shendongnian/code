    public static void Main()
    {
        int originalSize = Console.CursorSize;
    
        try
        {
           Console.CursorSize = 100; // Use "full" cursor
           ...  
        }
        finally 
        {
           // make sure we leave the cursor size as we found it.
           Console.CursorSize = originalSize;
        }
    }
