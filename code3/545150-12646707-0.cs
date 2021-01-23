    public static void Main( string[] args )
    {
      
      Console.TreatControlCAsInput = true ;
      
      Console.Write("? ") ;
      while ( true )
      {
        ConsoleKeyInfo keystroke = Console.ReadKey() ;
        Console.WriteLine();
        
        if ( keystroke.Modifiers == ConsoleModifiers.Control && keystroke.Key == ConsoleKey.C ) break ;
        
        int decimalDigit = ((int)keystroke.KeyChar) - ((int)'0') ;
        if ( decimalDigit >= 0 && decimalDigit <= 9 )
        {
          Console.WriteLine("Decimal Digit {0}", decimalDigit ) ;
        }
        else
        {
          Console.WriteLine( "Not a decimal digit!" ) ;
        }
        Console.Write("? ") ;
      }
      return;
    }
