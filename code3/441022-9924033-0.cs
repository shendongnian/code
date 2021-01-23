    public class StatesUserType : IUserType
    {
        private static readonly SqlType[] _sqlTypes = {
               NHibernateUtil.Int16.SqlType, NHibernateUtil.Int16.SqlType, 
               NHibernateUtil.Int16.SqlType, NHibernateUtil.Int16.SqlType  };
        public Type ReturnedType
        {
            get { return typeof(States); }
        }
        public SqlType[] SqlTypes
        {
            get { return _sqlTypes; }
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var result = States.None;
            if (((short)rs[names[0]]) == 1)
                result |= States.State1;
            if (((short)rs[names[1]]) == 1)
                result |= States.State2;
            if (((short)rs[names[2]]) == 1)
                result |= States.State3;
            if (((short)rs[names[3]]) == 1)
                result |= States.State4;
            return result;
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
                return;
            if (value.GetType() != typeof(States))
                return;
            var states = (States)value;
            cmd.Parameters[index] = states.HasFlag(States.State1);
            cmd.Parameters[index] = states.HasFlag(States.State2);
            cmd.Parameters[index] = states.HasFlag(States.State3);
            cmd.Parameters[index] = states.HasFlag(States.State4);
        }
        public bool IsMutable
        {
            get { return false; }
        }
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
            return object.Equals(x, y);
        }
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
