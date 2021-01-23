        public class Triplet : IEquatable<Triplet>
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public int Value3 { get; set; }
            public override int GetHashCode()
            {
                return Value1.GetHashCode() + Value2.GetHashCode() + Value3.GetHashCode();
            }
            public bool Equals(Triplet other)
            {
                int d1 = this.Value1.CompareTo(other.Value1);
                if (d1 != 0)
                    return false;
                int d2 = this.Value2.CompareTo(other.Value2);
                if (d2 != 0)
                    return false;
                int d3 = this.Value3.CompareTo(other.Value3);
                if (d3 != 0)
                    return false;
                return true;
            }
        }
