    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;
    [Serializable] //to allow NH configuration serialization
    public class GuidTypeConverter : IUserType
    {
        SqlType[] sqlTypes;
        public GuidTypeConverter()
        {
            sqlTypes = new[] { SqlTypeFactory.GetSqlType(DbType.Guid, 0, 0) };
        }
        
        public SqlType[] SqlTypes
        {
            get { return sqlTypes; }
        }
        public Type ReturnedType
        {
            get { return typeof(Guid); }
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            if (rs[names[0]] == DBNull.Value)
            {
                return Guid.Empty;
            }
            return (Guid) rs[names[0]];
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var param = (IDataParameter) cmd.Parameters[index];
            param.DbType = sqlTypes[0].DbType;
            var guid = (Guid) value;
            
            if (guid != Guid.Empty)
            {
                param.Value = guid;    
            }
            else
            {
                param.Value = DBNull.Value;
            }
        }
        public bool IsMutable
        {
            //guid is struct so it's not mutable
            get { return false; }
        }
        public object DeepCopy(object value)
        {
            return value;
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
        public object Assemble(object cached, object owner)
        {
            return cached;
        }
        public object Disassemble(object value)
        {
            return value;
        }
        public new bool Equals(object x, object y)
        {
            return x != null && x.Equals(y); 
        }
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
    }
