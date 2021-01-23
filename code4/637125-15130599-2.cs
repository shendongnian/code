    public class Enums2
    {
      [Flags] public enum Bits {none = 0, aBit = 1, bBit = 2, cBit = 4, dBit = 8};
      public static readonly Bits allBits;
      static Enums2()
      {
        allBits = Bits.none;
        foreach (Bits b in Enum.GetValues(typeof(Bits)))
        {
          allBits |= b;
        }
      } // static ctor
      public static Bits OtherBits(Bits x)
      // Returns all the Bits not on in x
      {
        return x ^ allBits;
      } // OtherBits
      // ...
      Bits    someBits = Bits.aBit | Bits.dBit;
      Bits missingBits = OtherBits(someBits); // gives bBit and cBit
    } // Enums2
