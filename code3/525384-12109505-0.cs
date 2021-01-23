    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace StackOverFlowDateSpan
    {
    [StructLayout(LayoutKind.Auto)]
    [Serializable]
    public struct DateSpan : IComparable, IComparable<DateSpan>, IEquatable<DateSpan>
    {
        public DateSpan(DateTime start, DateTime end)
            : this()
        {
            Start = start;
            End = end;
        }
        #region Properties
        public TimeSpan Duration
        {
            get { return TimeSpan.FromTicks((End - Start).Ticks); }
        }
        public DateTime End { get; private set; }
        public DateTime Start { get; private set; }
        #endregion
        public int CompareTo(DateSpan other)
        {
            long otherTicks = other.Duration.Ticks;
            long internalTicks = Duration.Ticks;
            return internalTicks > otherTicks ? 1 : (internalTicks < otherTicks ? -1 : 0);
        }
        public bool Equals(DateSpan other)
        {
            return End.Equals(other.End) && Start.Equals(other.Start);
        }
        public int CompareTo(object other)
        {
            if (other == null)
            {
                return 1;
            }
            if (!(other is DateSpan))
            {
                throw new ArgumentNullException("other");
            }
            return CompareTo((DateSpan)other);
        }
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            return other is DateSpan && Equals((DateSpan)other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (End.GetHashCode() * 397) ^ Start.GetHashCode();
            }
        }
        public static bool operator ==(DateSpan left, DateSpan right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(DateSpan left, DateSpan right)
        {
            return !left.Equals(right);
        }
        private sealed class EndStartEqualityComparer : IEqualityComparer<DateSpan>
        {
            #region IEqualityComparer<DateSpan> Members
            public bool Equals(DateSpan x, DateSpan y)
            {
                return x.End.Equals(y.End) && x.Start.Equals(y.Start);
            }
            public int GetHashCode(DateSpan obj)
            {
                unchecked
                {
                    return (obj.End.GetHashCode() * 397) ^ obj.Start.GetHashCode();
                }
            }
            #endregion
        }
        private static readonly IEqualityComparer<DateSpan> _endStartComparerInstance = new EndStartEqualityComparer();
        public static IEqualityComparer<DateSpan> EndStartComparer
        {
            get { return _endStartComparerInstance; }
        }
    }
    }
