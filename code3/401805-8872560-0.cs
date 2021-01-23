    namespace MyApp.Persistence {
        public class EnumMapper<T> : IUserType {
            public bool IsMutable {
                get { return false; }
            }
            public Type ReturnedType {
                get { return typeof (T); }
            }
            public SqlType[] SqlTypes {
                get { return new[] { SqlTypeFactory.Int16 }; }
            }
    
            public object NullSafeGet (IDataReader rs, string[] names, object owner) {
                var tmp = NHibernateUtil.Int32.NullSafeGet (rs, names[0]).ToString ();
    
                return Enum.Parse (typeof (T), tmp);
            }
    
            public void NullSafeSet (IDbCommand cmd, object value, int index) {
                if (value == null) {
                    ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
                }
                else {
                    ((IDataParameter)cmd.Parameters[index]).Value = (int)value;
                }
            }
    
            public object DeepCopy (object value) {
                return value;
            }
    
            public object Replace (object original, object target, object owner) {
                return original;
            }
    
            public object Assemble (object cached, object owner) {
                return cached;
            }
    
            public object Disassemble (object value) {
                return value;
            }
    
            public new bool Equals (object x, object y) {
                if (ReferenceEquals (x, y)) {
                    return true;
                }
    
                if (x == null || y == null) {
                    return false;
                }
    
                return x.Equals (y);
            }
    
            public int GetHashCode (object x) {
                return x == null ? typeof (T).GetHashCode () : x.GetHashCode ();
            }
        }
    }
