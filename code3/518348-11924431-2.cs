    public class Instrument : IEquatable<Instrument>
    {
      /* all the useful stuff you already have */
      public bool Equals(Instrument other)
      {
        return other != null && Id == other.Id;
      }
      public override bool Equals(object other)
      {
        return Equals(other as Instrument);
      }
      public override int GetHashCode()
      {
        return Id;
      }
    }
