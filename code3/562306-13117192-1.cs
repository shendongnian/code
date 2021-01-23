    public class BytesUserType : IUserType
    {
        private static readonly NHibernate.SqlTypes.SqlType[] _sqlTypes = { NHibernateUtil.Binary.SqlType };
        public NHibernate.SqlTypes.SqlType[] SqlTypes { get { return _sqlTypes; } }
        public Type ReturnedType { get { return typeof(Bytes); } }
        public bool IsMutable { get { return false; } }
        public object NullSafeGet(IDataReader dr, string[] names, object owner)
        {
            object obj = NHibernateUtil.Binary.NullSafeGet(dr, names[0]);
            if (obj == null)
                return null;
            var value = (byte[])obj;
            return new Bytes(value);
        }
        public void NullSafeSet(IDbCommand cmd, object obj, int index)
        {
            if (obj == null)
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            else
            {
                Bytes a = (Bytes)obj;
                byte[] valueBytes = a.Value;
                ((IDataParameter)cmd.Parameters[index]).Value = valueBytes;
            }
        }
        
        public new bool Equals(object x, object y) {...}
        public object DeepCopy(object value) {...}
        public int GetHashCode(object x) {...}
        public object Replace(object original, object target, object owner) {...}
        public object Assemble(object cached, object owner) {...}
        public object Disassemble(object value) {...}
    }
