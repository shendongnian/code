     public static void Main() 
        {
            DisplayHashCode( "Abcdei" );
        }
    static void DisplayHashCode( String Operand )
    {
        int     HashCode = Operand.GetHashCode( );
        Console.WriteLine("The hash code for \"{0}\" is: 0x{1:X8}, {1}",
                          Operand, HashCode );
    }
