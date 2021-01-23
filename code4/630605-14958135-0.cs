    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;
    namespace MCC.Common.DL.BaseObjects
    {
    public class SerializableUserType<originalType> : IUserType
    {
        public SqlType[] SqlTypes
        {
            get
            {
                SqlType[] types = new SqlType[1];
                types[0] = new SqlType(DbType.String);
                return types;
            }
        }
        public System.Type ReturnedType
        {
            get { return typeof(originalType); }
        }
        public new bool Equals(object x, object y)
        {
            if (x == null)
            {
                return false;
            }
            else
            {
                return x.Equals(y);
            }
        }
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            string txt = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
            return StringSerializer<originalType>.DeSerialize(txt);
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }
            var wrt = StringSerializer<originalType>.Serialize((originalType)value);
            NHibernateUtil.String.NullSafeSet(cmd, wrt, index);
        }
        public object DeepCopy(object value)
        {
            if (value == null) return null;
            return StringSerializer<originalType>.DeSerialize(StringSerializer<originalType>.Serialize((originalType)value));            
        }
        public bool IsMutable
        {
            get { return false; }
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
    }
