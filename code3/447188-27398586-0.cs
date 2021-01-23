            public static void Parse( string address )
            {
               string sheet;
               string col;
               int row;
               int sheetLength = address.IndexOf( '!' );
               if ( sheetLength > 0 )
               {
                  sheet = address.Substring( 0, sheetLength );
               }
               else
               {
                   sheet = string.Empty;
               }
               ++sheetLength; //skip the ! or start at 0
               int i = sheetLength;
               StringBuilder sb = new StringBuilder( );
               for( ; i < address.Length
                       && ! Char.IsDigit( address[ i ] ) 
                    ; ++i )
               {
                   sb.Append( address[ i ] );
               }
               col = sb.ToString( );
               sb.Clear( );
               for ( ; i < address.Length
                        && Char.IsDigit( address[ i ] )
                     ; ++i )
               {
                   sb.Append( address[ i ] );
               }
               row = Int32.Parse( sb.ToString( ) );
           }
