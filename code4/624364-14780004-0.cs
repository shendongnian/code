    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace ConsoleApplication6
    {
      class Program
      {
        
        static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create() ;
        
        static readonly byte[] buffer = {0,0} ;
        
        static char RandomChar()
        {
          ushort codepoint ;
          do
          {
            Random.GetBytes(buffer) ;
            codepoint = BitConverter.ToChar(buffer,0) ;
            codepoint &= 0x007F ; // restrict to Unicode C0 ;
          } while ( codepoint < 0x0020 ) ;
          return (char) codepoint ;
        }
        
        static IEnumerable<char> GetRandomChars( int count )
        {
          if ( count < 0 ) throw new ArgumentOutOfRangeException("count") ;
          
          while ( count-- >= 0 )
          {
            yield return RandomChar() ;
          }
        }
        
        enum Style
        {
          StringBuilder = 1 ,
          StringConcatFunction = 2 ,
          StringConstructor = 3 ,
        }
        
        static readonly StringBuilder sb = new StringBuilder() ;
        static string MakeString( Style style )
        {
          IEnumerable<char> chars = GetRandomChars(1000) ;
          string instance ;
          switch ( style )
          {
          case Style.StringConcatFunction :
            instance = String.Concat<char>( chars ) ;
            break ;
          case Style.StringBuilder : 
            foreach ( char ch in chars )
            {
              sb.Append(ch) ;
            }
            instance = sb.ToString() ;
            break ;
          case Style.StringConstructor :
            instance = new String( chars.ToArray() ) ;
            break ;
          default :
            throw new InvalidOperationException() ;
          }
          return instance ;
        }
        static void Main( string[] args )
        {
          Stopwatch stopwatch = new Stopwatch() ;
          
          foreach ( Style style in Enum.GetValues(typeof(Style)) )
          {
            stopwatch.Reset() ;
            stopwatch.Start() ;
            for ( int i = 0 ; i < 10000 ; ++i )
            {
              MakeString( Style.StringBuilder ) ;
            }
            stopwatch.Stop() ;
            Console.WriteLine( "Style={0}, elapsed time is {1}" ,
              style ,
              stopwatch.Elapsed
              ) ;
          }
          return ;
        }
      }
    }
