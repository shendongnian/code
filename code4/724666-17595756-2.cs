    public class TestItem
    {
        private static readonly MemberEqualityComparer<TestItem> Comparer = new MemberEqualityComparer<TestItem>()
            .Add(o => o.BoolValue)
            .Add(o => o.DateTimeValue)
            .Add(o => o.DoubleValue) // IEqualityComparer<double> can (and should) be specified here
            .Add(o => o.EnumValue)
            .Add(o => o.LongValue)
            .Add(o => o.StringValue)
            .Add(o => o.NullableDecimal);
        // property list is the same
        public override bool Equals(object obj)
        {
            return Comparer.Equals(this, obj);
        }
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }
    }
