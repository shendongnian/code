    public class NullableInjection : LoopInjection
    {
        public NullableInjection() : base() { }
        public NullableInjection(string[] ignoredProps) : base(ignoredProps) { }
        protected override bool MatchTypes(Type source, Type target)
        {
            // This is the most likely scenario test for it first.
            bool result = source == target;
            // if not a type match then lets do more expensive tests.
            if (!result)
            {
                var snt = Nullable.GetUnderlyingType(source);
                var tnt = Nullable.GetUnderlyingType(target);
                // Make sure that underlying types have not reverted to null       
                // this will cause false positives.
                result = ((source == target)
                       || ((tnt != null) && source == tnt)
                       || ((snt != null) && target == snt)
                       || ((tnt != null) && snt == tnt));
            }
            return result;
        }
    }
}
