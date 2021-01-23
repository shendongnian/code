    // in mapping
    Map(x => x.Color).Column("ColorARGB").CustomType<ColorUserType>();
    [Serializable]
    class ColorUserType : IUserType
    {
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }
        public object DeepCopy(object value)
        {
            return value;
        }
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }
        bool IUserType.Equals(object x, object y)
        {
            return Object.Equals(x, y);
        }
        public virtual int GetHashCode(object x)
        {
            return (x != null) ? x.GetHashCode() : 0;
        }
        public bool IsMutable { get { return false; } }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            return Color.FromArgb((int)NHibernateUtil.Int32.Get(rs, names[0]));
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            NHibernateUtil.Int32.Set(cmd, ((Color)value).ToArgb(), index);
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
        public Type ReturnedType { get { return typeof(Color); } }
        public SqlType[] SqlTypes { get { return new []{ SqlTypeFactory.Int32 }; } }
    }
