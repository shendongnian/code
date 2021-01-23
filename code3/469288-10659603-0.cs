     public static int StringToInt( char[] ch )
            {
                int length = ch.Length;
                int i = 0;
                int lastNumber = 0;
                int returnNumber = 0;
                bool numberNegative = false;
                int startPoint = 0;
    
                if ( ch[ 0 ] == '-' )
                {
                    numberNegative = true;
                    startPoint = 1;
                }
    
                for ( i = startPoint; i < length; i++ )
                {
                    if ( ch[ i ] == ' ' )
                    {
                        continue;
                    }
                    else
                    {
                        if ( ( ch[ i ] >= '0' ) && ch[ i ] <= '9' )
                        {
                            returnNumber = ch[ i ] - '0';
                            if ( i > 0 )
                                lastNumber = lastNumber * 10;
                            lastNumber = lastNumber + returnNumber;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if ( numberNegative )
                    lastNumber = -1 * lastNumber;
    
                return lastNumber;
            }
