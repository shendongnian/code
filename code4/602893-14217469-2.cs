    class MyStuff : IComparable<MyStuff>, IEquatable<MyStuff> {
      public const int A_INDEX = 0;
      public const int B_INDEX = 0;
      public MyStuff() {
        ValueA = null;
        ItemB = 0;
      }
      public string ValueA { get; set; }
      public int ItemB { get; set; }
      #region IComparable<MyStuff> Members
      public int CompareTo(MyStuff other) {
        if (other != null) {
          if (!String.IsNullOrEmpty(ValueA) && !String.IsNullOrEmpty(other.ValueA)) {
            int compare = ValueA.CompareTo(other.ValueA);
            if (compare == 0) {
              compare = ItemB.CompareTo(other.ItemB); // no null test for this
            }
            return compare;
          } else if (!String.IsNullOrEmpty(other.ValueA)) {
            return -1;
          }
        }
        return 1;
      }
      #endregion
      #region IEquatable<MyStuff> Members
      public bool Equals(MyStuff other) {
        int compare = CompareTo(other);
        return (compare == 0);
      }
      #endregion
    }
