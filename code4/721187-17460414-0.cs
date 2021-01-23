    class Accumulator
    {
      
      public Accumulator Add( int n )
      {
        min = min.HasValue && min.Value < n ? min.Value : n ;
        max = max.HasValue && max.Value > n ? max.Value : n ;
        return this ;
      }
      
      private int? min = null ;
      private int? max = null ;
      
      public int Min { get { return min.Value     ; } }
      public int Max { get { return max.Value     ; } }
      public int Range { get { return (Max-Min)+1 ; } }
      
      public override string  ToString()
      {
        return string.Format( "Min:{0}, Max:{1}, Range:{2}" , Min , Max , Range ) ;
      }
      
    }
