    public class Client : IEquatable<Client>
    {
      public string PropertyToCompare;
      public bool Equals(Client other)
      {
        return other.PropertyToCompare == this.PropertyToCompare;
      }
    }
