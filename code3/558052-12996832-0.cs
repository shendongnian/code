    public abstract class DateTimeAsStringType : IUserType
    {
        public object Assemble(object cached, object owner)
        {
            return cached;
        }
        public object DeepCopy(object value)
        {
            return value;
        }
        public object Disassemble(object value)
        {
            return value;
        }
        public bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null && y == null)
                return false;
            return x.Equals(y);
        }
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
        public bool IsMutable
        {
            get { return false; }
        }
        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            var serialized = NHibernateUtil.String.NullSafeGet(rs, names[0]) as string;
            
            if (string.IsNullOrEmpty(serialized))
                return null;
            return Deserialize(serialized);
        }
        protected abstract DateTime Deserialize(string value);
        protected abstract string Serialize(DateTime value);
        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            if (value == null)
                NHibernateUtil.String.NullSafeSet(cmd, DBNull.Value, index);
            else
                NHibernateUtil.String.NullSafeSet(cmd, Serialize((DateTime)value), index);
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
        public Type ReturnedType
        {
            get { return typeof(DateTime); }
        }
        public NHibernate.SqlTypes.SqlType[] SqlTypes
        {
            get { return new[] { NHibernateUtil.String.SqlType }; }
        }
    }
    public class TruncatedDateTimeAsStringType : DateTimeAsStringType
    {
        private const string Format = "yyyy-MM-dd";
        protected override string Serialize(DateTime value)
        {
            return value.ToString(Format, CultureInfo.InvariantCulture);
        }
        protected override DateTime Deserialize(string value)
        {
            return DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
    public class FullDateTimeAsStringType : DateTimeAsStringType
    {
        private const string Format = "yyyy-MM-dd hh:mm:ss";
        protected override string Serialize(DateTime value)
        {
            return value.ToString(Format, CultureInfo.InvariantCulture);
        }
        protected override DateTime Deserialize(string value)
        {
            return DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
