            float Dollaro = 1.32f, Euro, Cambio;
            string EuroStr;
            ConsoleKeyInfo risposta;
            do
            {
                Console.Write ( "Euro: " );
                EuroStr = Console.ReadLine ();
                bool result = Single.TryParse ( EuroStr, out Euro );
                if ( result )
                {
                    Cambio = Dollaro * Euro;
                    Console.WriteLine ( "Dollaro: " + Cambio );
                } else {
                    Console.WriteLine ( "Please enter a number" );
                }
                bool check = false;
                do {
                    Console.Write ( "\nVuoi continuare? (yes/no) " );
                    risposta = Console.ReadKey ( true );
                    check = !( ( risposta.Key == ConsoleKey.Y ) || ( risposta.Key == ConsoleKey.N ) );
                } while ( check );
                switch ( risposta.Key )
                {
                    case ConsoleKey.Y: Console.WriteLine ( "Yes" ); break;
                    case ConsoleKey.N: Console.WriteLine ( "No" ); break;
                } 
            } while ( risposta.Key != ConsoleKey.N );
