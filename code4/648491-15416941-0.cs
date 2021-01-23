    static bool IsPrime( int n )
    {
      if ( n < 1 ) throw new ArgumentOutOfRangeException("n") ;
      
      bool isPrime = true ;
      if ( n > 2 )
      {
        
        isPrime = ( 0 != n & 0x00000001 ) ; // eliminate all even numbers
        
        if ( isPrime )
        {
          int limit = (int) Math.Sqrt(n) ;
          for ( int i = 3 ; i <= limit && isPrime ; i += 2 )
          {
            isPrime = ( 0 != n % i ) ;
          }
        }
      }
      return isPrime ;
    }
