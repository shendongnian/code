    public class Role : IEquatable<Role> {
      public bool Equals(Role compare) {
        return compare != null && this.Name == compare.Name;
      }
      public override bool Equals(object compare) {
         return this.Equals(compare as Role); // this will call the above equals method
      }
      public override int GetHashCode() {
         return this.Name == null ? 0 : this.Name.GetHashCode();
      }
    }
