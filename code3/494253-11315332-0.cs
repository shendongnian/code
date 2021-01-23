    public class DateTakenComparer : IEqualityComparer<InspectionReading>
    {
        public bool Equals(InspectionReading x, InspectionReading y)
        {
            return x.DateTaken == y.DateTaken;
        }
        public int GetHashCode(InspectionReading obj)
        {
            return obj.GetHashCode();
        }
    }
