    Map(x => x.Args).CustomType<ObjectArrayType>();
    
    class ObjectArrayType : IUserType
    {
        public object NullSafeGet(IDBReader reader, string[] names, object owner)
        {
            byte[] bytes = NHibernateUtil.BinaryBlob.NullSafeGet(reader, names[0]);
            return Deserialize(bytes);
        }
    
        public void NullSafeSet(IDBCommand cmd, object value, int index)
        {
            var args = (object[])value;
            NHibernateUtil.BinaryBlob.NullSafeSet(cmd, Serialize(args), index);
        }
    
        public Type ReturnType
        {
            get { return typeof(object[]); }
        }
    
        public SqlType[] SqlTypes
        {
            get { return new [] { SqlTypeFactory.BinaryBlob } }
        }
    }
