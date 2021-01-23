       public static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            for ( i = 0; i < 4; i++ )
            {
                for ( j = 0; j < 4; j++ )
                {
                    if ( j < 3 - i )
                        Console.Write(" ");
                    else
                        Console.Write("█");
                }
                Console.Write('\n');
            }
            
            Console.ReadKey();
        }
