    class Program
    {
      static void Main( string[] args )
      {
        string myFileName = @"c:\foo\bar\baz.txt" ;
        Queue<string> queue = new Queue<string>( File.ReadAllLines(myFileName).Shuffle() ) ;
      }
    }
    /// <summary>
    /// A few helper methods
    /// </summary>
    static class ExtensionMethods
    {
      /// <summary>
      /// Performs an in-place shuffle of an array
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="instance"></param>
      /// <returns></returns>
      public static T[] Shuffle<T>( this T[] instance )
      {
        for ( int i = 0 ; i < instance.Length ; ++i )
        {
          int j = rng.Next(i,instance.Length ) ; // select a random j such that i <= j < instance.Length
          
          // swap instance[i] and instance[j]
          T x = instance[j] ;
          instance[j] = instance[i] ;
          instance[i] = x ;
          
        }
        
        return instance ;
      }
      private static readonly Random rng = new Random() ;
      
    }
