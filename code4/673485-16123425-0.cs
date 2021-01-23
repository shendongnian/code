     public interface IComparableProperty
        {
            bool IsBetterThan(object target);
            bool IsBetterThan(IEnumerable targets);
        }
        public abstract class ComparableProperty<T>: IComparableProperty where T : IComparable<T>
        {
            T Value { get; set; }
            public ComparisonType ComparisonType { get; set; }
            public bool IsBetterThan(T target)
            {
                if (ComparisonType == ComparisonType.GreaterThan)
                    return Value.CompareTo(target) >= 0;
                return Value.CompareTo(target) <= 0;
            }
            public bool IsBetterThan(IEnumerable<T> targets)
            {
                foreach (var target in targets)
                {
                    if (ComparisonType == ComparisonType.SmallerThan && Value.CompareTo(target) >= 0)
                        return false;
                    if (ComparisonType == ComparisonType.GreaterThan && Value.CompareTo(target) <= 0)
                        return false;
                }
                return true;
            }
            bool IComparableProperty.IsBetterThan(object target)
            {
                return IsBetterThan((T) target);
            }
            bool IComparableProperty.IsBetterThan(IEnumerable targets)
            {
                return IsBetterThan((IEnumerable<T>) (targets));
            }
        }
