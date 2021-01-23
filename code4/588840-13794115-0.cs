    for( int player = 1; player <= 4; player++ )
    {
        while(1) {
            int DiceThrow = DiceRandom.Next(1, 7);
            Console.WriteLine( "Player " + player + " rolled a " + DiceThrow );
            if( DiceThrow < 6 ) break;
        }
        Console.ReadLine();
    }
