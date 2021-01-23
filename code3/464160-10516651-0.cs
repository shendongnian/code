    public class ComboBoxItem : IEquatable<ComboBoxItem> {
      // class stuff
      public bool Equals(ComboBoxItem other) {
        return (this.ToString() == other.ToString());
      }
      public override bool Equals(object obj) {
        if (obj == null)
          return base.Equals(obj);
        if (obj is ComboBoxItem)
          return this.Equals((ComboBoxItem)obj);
        else
          return false;
      }
      public override int GetHashCode() {
        return this.ToString().GetHashCode();
      }
    }
