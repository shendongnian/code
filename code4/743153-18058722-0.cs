    public class Role : IEquatable<Role> {
      public bool Equals(Role compare) {
        return compare != null && this.Name == compare.Name;
      }
    }
