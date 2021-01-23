    public struct Int128 : IComparable, IFormattable, IConvertible, IComparable<Int128_done>, IEquatable<Int128_done>
    
    {
      private ulong _lo;
      private long _hi;
    
      public Int128(UInt64 low, Int64 high)
      {
        _lo = low;
        _hi = high;
      }
    }
