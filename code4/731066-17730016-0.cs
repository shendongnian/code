    public class ESHClass : IComparable<ESHClass> {
      public ESHClass() {
        TimeStamp = DateTime.MinValue;
      }
      public string PolicyNumber { get; set; }
      public string PolicyMod { get; set; }
      public string MultiPolicy { get; set; }
      public string HasSwimmingPool { get; set; }
      public DateTime TimeStamp { get; set; }
      public int CompareTo(ESHClass other) {
        int value = PolicyNumber.CompareTo(other.PolicyNumber);
        if (value == 0) {
          value = TimeStamp.CompareTo(other.TimeStamp);
        }
        return value;
      }
      public override string ToString() {
        return PolicyNumber;
      }
    }
